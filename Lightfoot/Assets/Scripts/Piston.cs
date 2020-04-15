using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public Animator animator;
    public Lever lever;

    // Update is called once per frame
    void Update()
    {
        if (lever.activated) animator.SetBool("Open", true);
        else animator.SetBool("Open", false);
    }
}
