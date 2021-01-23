using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FistSlam : MonoBehaviour
{
    public bool smash;

    public float speed;
    public float delta;

    private SpriteRenderer sprite;
    private Vector3 initialPosition;
    private Vector3 finalPosition;

    // Start is called at the beginning of the first frame
    void Start() {
        smash = false;
        sprite = GetComponent<SpriteRenderer>();
        finalPosition = transform.position;
        initialPosition = new Vector3(transform.position.x, transform.position.y + delta, transform.position.z);
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update() {
        if (smash)
        {
            smashFist();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void startSmash()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        finalPosition = GameObject.Find("Player").transform.position;
        transform.position = new Vector2(finalPosition.x, finalPosition.y + delta);
        smash = true;
    }

    void smashFist()
    {
        transform.position = Vector3.MoveTowards(transform.position, finalPosition, speed * Time.deltaTime);
        if (transform.position == finalPosition)
        {
            Color color = sprite.color;
            color.a = 1f;
            StartCoroutine(FadeTo(sprite, 0f, 1.5f));
        }
        if (sprite.color.a == 0f)
        {
            transform.position = initialPosition;
            smash = false;
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
