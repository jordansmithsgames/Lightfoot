using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator animator;
    public bool pressed = false;
    private GameObject LeftFist;
    private GameObject RightFist;
    // Start is called before the first frame update
    void Start()
    {
        LeftFist = GameObject.Find("Left Fist");
        RightFist = GameObject.Find("Right Fist");
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool LeftWithinX = LeftFist.transform.position.x >= gameObject.transform.position.x - 0.5 && LeftFist.transform.position.x <= gameObject.transform.position.x + 0.5;
        bool LeftWithinY = LeftFist.transform.position.y >= gameObject.transform.position.y && LeftFist.transform.position.y <= gameObject.transform.position.y + 1.5;
        bool RightWithinX = RightFist.transform.position.x >= gameObject.transform.position.x - 0.5 && RightFist.transform.position.x <= gameObject.transform.position.x + 0.5;
        bool RightWithinY = RightFist.transform.position.y >= gameObject.transform.position.y && RightFist.transform.position.y <= gameObject.transform.position.y + 1.5;
        if ((LeftWithinX && LeftWithinY) || (RightWithinX && RightWithinY))
            pressed = true;

        if (animator)
            animator.SetBool("Pressed", pressed);
    }
}
