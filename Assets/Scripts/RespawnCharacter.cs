using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source
// https://www.youtube.com/watch?v=nBgCeJBMT0k

public class RespawnCharacter : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform character;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player character collides with DeathFloor, respawn and lose a life
        CharacterController2D playerController = collision.GetComponent<CharacterController2D>();
        Rigidbody2D playerBody = collision.GetComponent<Rigidbody2D>();

        if (playerController.invulnerabilityCount <= 0)
        {
            SoundManagerScript.PlaySound("EryHurt");
            playerController.CharacterLives -= 1;
            playerController.invulnerabilityCount = 1f;

            if (playerController.CharacterLives > 0) // Only respawn if game is not over
            {
                StartCoroutine(Respawn(playerBody));
            }
        }
    }

    IEnumerator Respawn(Rigidbody2D playerBody)
    {
        // Used to add a small delay before respawn

        yield return new WaitForSeconds(2);

        // Stop player momentum from fall
        playerBody.velocity = Vector2.zero;
        playerBody.angularVelocity = 0f;

        character.transform.position = respawnPoint.transform.position;
    }
}
