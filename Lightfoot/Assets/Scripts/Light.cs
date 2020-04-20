using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light : MonoBehaviour
{
    public Lever lever;
    public Button button;
    public bool lit;
    private bool opposite;
    private Light2D light;
    private float initIntensity;

    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light2D>();
        initIntensity = light.intensity;
        opposite = !lit;
        if (!lit) light.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lever)
        {
            if (lever.activated) lit = opposite;
            else if (!lever.activated) lit = !opposite;
        }
        if (button)
        {
            if (button.pressed) lit = opposite;
            else if (!button.pressed) lit = !opposite;
        }
        if (lit) light.intensity = initIntensity;
        else light.intensity = 0;
    }
}
