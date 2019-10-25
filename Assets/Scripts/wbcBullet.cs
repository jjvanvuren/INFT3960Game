using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source
// https://www.youtube.com/watch?v=wkKsl1Mfp5M

public class wbcBullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.tag);

        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }

        if (collision.tag != "Projectile" && collision.tag != "ScorePickup" && collision.tag != "Platelet" && collision.tag != "WhiteBloodCell")
        {
            Destroy(gameObject);
        }
    }
}
