using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] CircleCollider2D enemyCol;

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
            SoundManagerScript.PlaySound("Death");
            enemyCol.enabled = false; // Prevent damage to player
            anim.SetTrigger("Death");
            Invoke("Die", 0.4f);
        }
    }
    
    void Die()
    {
        // Destroy the enemy game object
        Destroy(gameObject);
    }
}
