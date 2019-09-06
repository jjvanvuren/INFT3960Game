using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Source: https://www.youtube.com/watch?v=xIevsYimJYc & https://www.youtube.com/watch?v=TatAnGj1RMg
    public GameObject PauseUI;
    private bool paused = false;

    private void Start()
    {

        PauseUI.SetActive(false);

    }

    private void Update()
    {

        if(Input.GetButtonDown("Pause"))
        {

            paused = !paused;

        }

        if (paused)
        {

            PauseUI.SetActive(true);
            Time.timeScale = 0;

        }

        if(!paused)
        {

            PauseUI.SetActive(false);
            Time.timeScale = 1;

        }
    }

    public void Resume()
    {

        paused = false;

    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void TitleScreen()
    {

        SceneManager.LoadScene(0);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
