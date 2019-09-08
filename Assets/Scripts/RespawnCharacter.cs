using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCharacter : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform character;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManagerScript.PlaySound("EryHurt");

        // When the player character collides with DeathFloor, respawn and lose a life

        var player = collision.GetComponent<CharacterController2D>();



        if (player.invulnerabilityCount <= 0)
        {
            player.CharacterLives -= 1;
            player.invulnerabilityCount = 1f;
            character.transform.position = respawnPoint.transform.position;
        }
    }
}
