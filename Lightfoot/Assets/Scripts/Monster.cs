using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject player;
    public LightMeter lightMeter;

    public float eyeSpeed = 1;
    public float eyeScaleX = 3;
    public float eyeScaleY = 1;
    public float fistSpeed = 10f;
    public float fistDropDistance = 5f;

    private GameObject LeftFist;
    private GameObject RightFist;
    private GameObject Eyes;

    private bool awakened;
    private bool leftSlammed;
    private bool rightSlammed;

    private SpriteRenderer eyeSprite;
    private Vector3 initEyePos;
    private Vector3 swayEyePos;
    private float countdown;

    private Vector3 initLFirstPos;
    private Vector3 initRFistPos;
    private Vector3 finalLFistPos;
    private Vector3 finalRFistPos;

    void Start()
    {
        LeftFist = gameObject.transform.Find("Left Fist").gameObject;
        RightFist = gameObject.transform.Find("Right Fist").gameObject;
        Eyes = gameObject.transform.Find("Eyes").gameObject;

        awakened = false;
        eyeSprite = Eyes.GetComponent<SpriteRenderer>();
        initEyePos = transform.position;
        swayEyePos = initEyePos;
        countdown = 5f;

        leftSlammed = false;
        rightSlammed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (awakened)
        {
            transform.position = swayEyePos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * eyeSpeed) * eyeScaleX - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * eyeSpeed) * eyeScaleY);
            if (eyeSprite.color.a == 1) StartCoroutine(FadeTo(eyeSprite, 0f, 3f));
            if (eyeSprite.color.a == 0) StartCoroutine(FadeTo(eyeSprite, 1f, 3f));

            if (leftSlammed == false && player.GetComponent<CharacterController2D>().getGrounded())
            {
                LeftFist.GetComponent<FistSlam>().startSmash();
                leftSlammed = true;
            }
            else if (rightSlammed == false && LeftFist.GetComponent<FistSlam>().smash == false && leftSlammed == true && player.GetComponent<CharacterController2D>().getGrounded())
            {
                RightFist.GetComponent<FistSlam>().startSmash();
                rightSlammed = true;
            }

            countdown -= Time.deltaTime;
            if (countdown < 0)
            {
                leftSlammed = false;
                rightSlammed = false;
                awakened = false;
                swayEyePos = initEyePos;
            }
        }
        else if (lightMeter.getIllumination() == 7) 
        {
            countdown = 5f;
            awakened = true;
        }
        Debug.Log("Left Slammed: " + leftSlammed);
        Debug.Log("Right Slammed: " + rightSlammed);
    }

    IEnumerator FadeTo(SpriteRenderer sprite, float targetOpacity, float duration)
    {
        // Cache the current color of the material, and its initiql opacity.
        Color color = sprite.color;
        float startOpacity = color.a;

        // Track how many seconds we've been fading.
        float t = 0;

        while (t < duration)
        {
            // Step the fade forward one frame.
            t += Time.deltaTime;
            // Turn the time into an interpolation factor between 0 and 1.
            float blend = Mathf.Clamp01(t / duration);

            // Blend to the corresponding opacity between start & target.
            color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);

            // Apply the resulting color to the material.
            sprite.color = color;

            // Wait one frame, and repeat.
            yield return null;
        }
    }

    public bool getAwakened()
    {
        return awakened;
    }
}