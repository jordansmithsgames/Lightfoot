using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropdown : MonoBehaviour
{
    private PlatformEffector2D effector;
    private BoxCollider2D collided;
    private Collider2D platform;

    void Start()
    {
        effector = gameObject.GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            Flip();
            Invoke("Flip", 0.3f);
        }
    }

    private void Flip()
    {
        if (effector.rotationalOffset == 180f) effector.rotationalOffset = 0f;
        else effector.rotationalOffset = 180f;
    }
}

