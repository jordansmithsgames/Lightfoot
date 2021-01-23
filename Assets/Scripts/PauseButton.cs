using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    PauseManager pauseManager;
    // Start is called before the first frame update
    void Start()
    {
        pauseManager = GameObject.Find("Player").GetComponent<PauseManager>();
    }

    // Update is called once per frame
    public void resume()
    {
        pauseManager.hidePaused();
    }
}
