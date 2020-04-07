﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FistSlam : MonoBehaviour
{
    public float speed = 10f;
    public float delta = 5f;

    private SpriteRenderer sprite;
    private Vector3 initialPosition;
    private Vector3 finalPosition;

    // Start is called at the beginning of the first frame
    void Start() {
        sprite = GetComponent<SpriteRenderer>();
        finalPosition = transform.position;
        initialPosition = new Vector3(transform.position.x, transform.position.y + delta, transform.position.z);
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, finalPosition, speed * Time.deltaTime);
        if (transform.position == finalPosition) StartCoroutine(FadeTo(sprite, 0f, 1f));
        if (sprite.color.a == 0f) {
            transform.position = initialPosition;
            StartCoroutine(FadeTo(sprite, 1f, 0.1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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