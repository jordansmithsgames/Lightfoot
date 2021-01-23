using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float length;
    public float speed;
    public float elbowRoom;
    public int platforms;
    public bool right;
    // Start is called before the first frame update
    void Start()
    {
        GameObject original = this.transform.GetChild(0).gameObject;
        for (int i = 1; i < platforms; i++)
        {
            if (!right) i *= -1;
            GameObject platform = Instantiate(original, new Vector3(this.transform.position.x + i * elbowRoom, this.transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0), this.transform);
            if (!right) i *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
