using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] CircleCollider2D enemyCol;
    [SerializeField] string enemyType;

    public Animator anim;

    public void TakeDamage (int damage)
    {
        if (health > 0)
        {
            SoundManagerScript.PlaySound("BaccyHurt");
        }

        health -= damage;

        if (health <= 0) // If enemy health is depleted, enemy dies
        {

            if (enemyType == "Patrol")
            {
                // Prevent damage to player
                BaccyPatrol bp = gameObject.GetComponent<BaccyPatrol>();
                bp.speed = 0f;
            }

            enemyCol.enabled = false;

            // Invoke Death
            SoundManagerScript.PlaySound("Death");
            anim.SetTrigger("Death");
            Invoke("Die", 0.6f);
        }
    }
    
    void Die()
    {
        // Destroy the enemy game object
        Destroy(gameObject);
    }
}
