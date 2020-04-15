using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lever : MonoBehaviour
{
    public Animator animator;
    public bool activated;
    private bool triggering;

    void Start() {
        animator.SetBool("Activated", activated);
        triggering = false;
    }

    void Update() {
        if (triggering && Input.GetButtonDown("Interact"))
        {
            animator.SetBool("Activated", !activated);
            activated = !activated;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        triggering = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        triggering = false;
    }
}
