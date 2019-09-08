using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EryDeath : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform character;
    public GameObject Ery;

    public Animator anim;
    //private GameOverMenuScript GameOver;

    private void Update()
    {
        var player = GameObject.Find("Ery").GetComponent<CharacterController2D>();
        
        int iLives = player.CharacterLives;
        if (iLives < 1)
        {
            
            player.CharacterLives = 4;
            GameObject.Find("Ery").GetComponent<PlayerMovement>().enabled = false;
            SoundManagerScript.PlaySound("Death");
            anim.SetTrigger("Dead");
            Invoke("GameOver", 1.5f);

            
        }
    }

    void GameOver()
    {
        // Show game over menu

        var gameOver = GameObject.Find("Main Camera").GetComponent<GameOverMenuScript>();
        gameOver.isGameOver = true;
    }
}
