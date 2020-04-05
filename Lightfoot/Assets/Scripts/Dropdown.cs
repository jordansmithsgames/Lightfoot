using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropdown : MonoBehaviour
{
    private PlatformEffector2D effector;
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
            Invoke("Flip", 0.5f);
        }
    }

    private void Flip()
    {
        if (effector.rotationalOffset == 180f) effector.rotationalOffset = 0f;
        else effector.rotationalOffset = 180f;
    }
}

