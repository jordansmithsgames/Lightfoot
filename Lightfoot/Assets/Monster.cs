using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    private SpriteRenderer sprite;

    private Vector3 startPos;

    public float speed = 1;
    public float xScale = 1;
    public float yScale = 1;

    void Start()
    {
        startPos = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed) * yScale);

        if (sprite.color.a == 1)
        {
            StartCoroutine(FadeTo(sprite, 0f, 3f));
        }

        if (sprite.color.a == 0)
        {
            StartCoroutine(FadeTo(sprite, 1f, 3f));
        }
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
}
