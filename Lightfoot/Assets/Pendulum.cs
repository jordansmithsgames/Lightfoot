using UnityEngine;
using System.Collections;

// Author: Eric Eastwood (ericeastwood.com)
//
// Description:
//		Written for this gd.se question: http://gamedev.stackexchange.com/a/75748/16587
//		Simulates/Emulates pendulum motion in code
// 		Works in any 3D direction and with any force/direciton of gravity
//
// Demonstration: https://i.imgur.com/vOQgFMe.gif
//
// Usage: https://i.imgur.com/BM52dbT.png
public class Pendulum : MonoBehaviour
{

    public GameObject Pivot;
    public GameObject Bob;

    private float time;
    private Vector3 position;

    float ropeLength;

    // Use this for initialization
    void Start()
    {
        this.ropeLength = Vector3.Distance(Pivot.transform.position, Bob.transform.position);
        time = 0;
        position.z = 0;
    }

    void FixedUpdate()
    {
        time += 0.02f;

        if (time >= 2 * Mathf.PI)
        {
            time = 0;
        }

        position.x = Mathf.Cos(time);
        position.y = Mathf.Abs(Mathf.Sin(time)) * -1;

        transform.Translate((position * ropeLength + Pivot.transform.position - this.transform.position) * (1.1f - Mathf.Abs(this.transform.position.x - Pivot.transform.position.x)/ropeLength));
    }
        
}