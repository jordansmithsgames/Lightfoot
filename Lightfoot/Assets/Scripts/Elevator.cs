using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float height;
    public float speed;
    public float elbowRoom;
    public int platforms;
    public bool up;
    // Start is called before the first frame update
    void Start()
    {
        GameObject original = this.transform.GetChild(0).gameObject;
        for (int i = 1; i < platforms; i++)
        {
            if (!up) i *= -1;
            GameObject platform = Instantiate(original, new Vector3(this.transform.position.x, this.transform.position.y + i * elbowRoom, transform.position.z), new Quaternion(0, 0, 0, 0), this.transform);
            if (!up) i *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
