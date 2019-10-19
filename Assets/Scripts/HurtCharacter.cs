using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source
// https://www.youtube.com/watch?v=sdGeGQPPW7E

public class HurtCharacter : MonoBehaviour
{
    private BaccyPatrol baccyBody;
    private CharacterController2D player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Ery")
        {
            player = collision.GetComponent<CharacterController2D>();
            baccyBody = GetComponent<BaccyPatrol>();

            // Check if character is vulnerable
            if (player.invulnerabilityCount <= 0)
            {
                SoundManagerScript.PlaySound("EryHurt");
                Animator anim = player.GetComponent<Animator>();
                anim.SetTrigger("Hurt");
                player.knockBackCount = player.knockBackLength;
                player.CharacterLives -= 1;
                player.invulnerabilityCount = 1f;
            }
            else if (player.CharacterLives < 1) // Only knockback if character is alive
            {
                baccyBody.speed = 0f; // Stop baccy from moving

                player.knockBackCount = 0;
                player.CharacterLives -= 1;
                player.invulnerabilityCount = 1f;
            }

            if (collision.transform.position.x < transform.position.x)
            {
                player.knockBackFromRight = true;
            }
            else
            {
                player.knockBackFromRight = false;
            }
        }
    }
}
