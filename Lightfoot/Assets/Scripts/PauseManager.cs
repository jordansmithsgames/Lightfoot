using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                showPaused();
            }
            else
            {
                hidePaused();
            }
        }
    }

    public void showPaused()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void hidePaused()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
