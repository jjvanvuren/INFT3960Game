using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 1;

    public Animator anim;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            anim.SetTrigger("Death");
            Invoke("Die", 0.4f);
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
}
