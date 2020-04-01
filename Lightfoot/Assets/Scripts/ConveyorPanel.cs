using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorPanel : MonoBehaviour
{
    float length;
    float speed;
    bool right;
    // Start is called before the first frame update
    void Start()
    {
        length = transform.parent.GetComponent<Conveyor>().length;
        speed = transform.parent.GetComponent<Conveyor>().speed;
        right = transform.parent.GetComponent<Conveyor>().right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed * 0.02f, 0, 0));

        if (transform.position.x >= transform.parent.position.x + length && right)
        {
            Transform player = null;
            try
            {
                player = transform.GetChild(0).GetChild(0);
            }
            catch (UnityException e){}
            if (player != null)
            {
                player.GetComponent<CharacterController2D>().DetachParent();
            }
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
        }

        else if (transform.position.x <= transform.parent.position.x - length)
        {
            Transform player = null;
            try
            {
                player = transform.GetChild(0).GetChild(0);
            }
            catch (UnityException e) { }
            if (player != null)
            {
                player.GetComponent<CharacterController2D>().DetachParent();
            }
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
        }
    }
}
