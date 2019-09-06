using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreenMenu : MonoBehaviour
{
    //Return to TitleScreen
    public void TitleScreen()
    {

        SceneManager.LoadScene(0);

    }
}
