using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightMeter : MonoBehaviour
{
    // Start is called before the first frame update
    Image img;

    public Sprite meter0;
    public Sprite meter1;
    public Sprite meter2;
    public Sprite meter3;
    public Sprite meter4;
    public Sprite meter5;
    public Sprite meter6;
    public Sprite meter7;

    Sprite[] meter;

    GameObject player;

    void Start()
    {
        img = this.gameObject.GetComponent<Image>();
        player = GameObject.Find("Player");
        meter = new Sprite[] { meter0, meter1, meter2, meter3, meter4, meter5, meter6, meter7 };
    }
    // Update is called once per frame
    void Update()
    {
        img.sprite = meter[player.GetComponent<CharacterController2D>().illuminationCounter  / 10];
    }
}
