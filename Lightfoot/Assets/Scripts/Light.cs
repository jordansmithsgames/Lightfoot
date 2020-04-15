using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light : MonoBehaviour
{
    public Lever lever;
    public bool lit = true;
    private Light2D light;
    private float initIntensity;

    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light2D>();
        initIntensity = light.intensity;
        if (!lit) light.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lever.activated) lit = true;
        else if (!lever.activated) lit = false;
        if (lit) light.intensity = initIntensity;
        else light.intensity = 0;
    }
}
