using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Source: https://www.youtube.com/watch?v=xIevsYimJYc & https://www.youtube.com/watch?v=TatAnGj1RMg
    public GameObject PauseUI;

    public bool paused = false;

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

            // Enable the mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }

        if(!paused)
        {

            PauseUI.SetActive(false);
            Time.timeScale = 1;

            // Hide and lock the mouse
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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

        SceneManager.LoadScene(1);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
