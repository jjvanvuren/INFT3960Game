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
        GameObject player = GameObject.Find("Ery");

        var playerController = player.GetComponent<CharacterController2D>();
        var playerBody = player.GetComponent<Rigidbody2D>();

        int iLives = playerController.CharacterLives;
        if (iLives < 1)
        {
            // Stop player momentum for death animation
            playerBody.velocity = Vector2.zero;
            playerBody.angularVelocity = 0f;
            playerBody.gravityScale = 0f;
            player.GetComponent<PlayerMovement>().enabled = false;

            // PLay death animation & sound
            SoundManagerScript.PlaySound("Death");
            anim.SetTrigger("Dead");

            playerController.CharacterLives = 4;
            Invoke("GameOver", 0.9f);
        }
    }

    void GameOver()
    {
        // Dont show Ery on game over
        Ery.GetComponent<Renderer>().enabled = false;

        // Show game over menu
        var gameOver = GameObject.Find("Main Camera").GetComponent<GameOverMenuScript>();
        gameOver.isGameOver = true;
    }
}
