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
        health -= damage;

        if (health <= 0) // If enemy health is depleted, enemy dies
        {
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
