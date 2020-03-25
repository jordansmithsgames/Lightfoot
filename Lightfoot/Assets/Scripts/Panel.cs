using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    float height;
    float speed;
    bool up;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.parent.GetComponent<Elevator>().height;
        speed = transform.parent.GetComponent<Elevator>().speed;
        up = transform.parent.GetComponent<Elevator>().up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, speed * 0.02f, 0));

        if (transform.position.y >= transform.parent.position.y + height && up)
        {
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
        }

        else if (transform.position.y <= transform.parent.position.y - height)
        {
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
        }
    }
}
