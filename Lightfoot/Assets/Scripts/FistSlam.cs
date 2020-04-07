using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class FistSlam : MonoBehaviour
{
    public float speed = 10f;
    public float delta = 5f;
    private Vector3 finalPosition;

    // Start is called at the beginning of the first frame
    void Start() {
        finalPosition = transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y + delta, transform.position.z);
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, finalPosition, speed * Time.deltaTime);
    }
}
