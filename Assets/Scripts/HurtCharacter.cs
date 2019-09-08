using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source
// https://www.youtube.com/watch?v=sdGeGQPPW7E

public class HurtCharacter : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Ery")
        {
            var player = collision.GetComponent<CharacterController2D>();

            // Check if character is vulnerable
            if (player.invulnerabilityCount <= 0)
            {
                anim.SetTrigger("Hurt");
                player.knockBackCount = player.knockBackLength;
                player.CharacterLives -= 1;
                player.invulnerabilityCount = 1f;
            }
            else if (player.CharacterLives < 1) // Only knockback if character is alive
            {
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
