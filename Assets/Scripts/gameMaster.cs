using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour
{
    //Source: https://www.youtube.com/watch?v=P-Ywfxg1_M4&list=PLq3pyCh4J1B2uSvypNOK_nxYKBt5mMCJt&index=23


    public int wbcCount;
    public int plateletCount;
    public int levelScore;
    public TextMeshProUGUI wbcCountText;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI PlateletCountText;

    public float countDown = 31f;
    private GameObject player;
    private CharacterController2D playerController;
    private string currentScene;

    private void Start()
    {
        // Hide and lock the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
        player = GameObject.Find("Ery");
        playerController = player.GetComponent<CharacterController2D>();

        wbcCountText.text = ("White Blood Cells: " + wbcCount);
        LivesText.text = ("Lives: " + playerController.CharacterLives);
        PlateletCountText.text = ("Platelets: " + plateletCount + "/10");

        

        if (currentScene == "Level3" && playerController.CharacterLives > 0)
        {
            countDown = countDownTimer(currentScene, countDown, playerController);
            GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>().text = "Oxygen Level: " + System.Math.Floor(countDown);
        }
    }

    // A level count down timer
    private float countDownTimer(string sceneName, float cTime, CharacterController2D pController)
    {
        cTime -= Time.deltaTime;
        Debug.Log(System.Math.Round(cTime));
        if (cTime < 0)
        {
            pController.CharacterLives = 0;
            cTime = 1f;
        }

        return cTime;
    }
}
