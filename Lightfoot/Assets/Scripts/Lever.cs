using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lever : MonoBehaviour
{
    public Animator animator;
    public Light2D lightbulb;
    public bool activated;

    private float intensity;
    private bool triggering = false;

    void Start() {
        intensity = lightbulb.intensity;
        animator.SetBool("Activated", activated);
        //UpdateLight();
    }

    void Update() {
        if (triggering && Input.GetButtonDown("Interact")) PullLever();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject.name);
        triggering = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        triggering = false;
    }

    void PullLever() {
        animator.SetBool("Activated", !activated);
       
        UpdateLight();
        activated = !activated;
    }

    void UpdateLight() {
        if (activated) lightbulb.intensity = intensity;
        else lightbulb.intensity = 0;
    }
}
