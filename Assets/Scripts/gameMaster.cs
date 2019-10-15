using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameMaster : MonoBehaviour
{
    //Source: https://www.youtube.com/watch?v=P-Ywfxg1_M4&list=PLq3pyCh4J1B2uSvypNOK_nxYKBt5mMCJt&index=23


    public int wbcCount;
    public int plateletCount;
    public TextMeshProUGUI wbcCountText;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI PlateletCountText;

    private void Start()
    {
        // Hide and lock the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var player = GameObject.Find("Ery").GetComponent<CharacterController2D>();

        wbcCountText.text = ("White Blood Cells: " + wbcCount);
        LivesText.text = ("Lives: " + player.CharacterLives);
        PlateletCountText.text = ("Platelets: " + plateletCount);

    }
}
