using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour
{
    public GameObject GameOverUI;
    public bool isGameOver = false;
    PauseMenu pauseMenu;

    private void Start()
    {

        GameOverUI.SetActive(false);

    }

    private void Update()
    {
        

        if (isGameOver)
        {
            pauseMenu = GameObject.Find("Main Camera").GetComponent<PauseMenu>();

            // Prevent player from triggering pause menu
            Destroy(pauseMenu);

            GameOverUI.SetActive(true);
            Time.timeScale = 0;

            // Enable the mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }

        if (!isGameOver && !pauseMenu.paused)
        {

            GameOverUI.SetActive(false);
            Time.timeScale = 1;

        }
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
