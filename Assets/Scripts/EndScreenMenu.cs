using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreenMenu : MonoBehaviour
{
    private void Start()
    {
        // Enable the mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Return to TitleScreen
    public void TitleScreen()
    {

        SceneManager.LoadScene(0);

    }
}
