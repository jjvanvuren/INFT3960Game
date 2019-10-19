using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaccySpit : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Ery");
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ery")
        {
            var player = collision.GetComponent<CharacterController2D>();

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

        if (collision.tag != "Projectile")
        {
            Destroy(gameObject);
        }
        
    }
}
