using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source
// https://www.youtube.com/watch?v=-mrGHaAdX8M

public class BaccyWallPatrol : MonoBehaviour
{
    public float speed;
    public int xMoveDirection;

    private void Update()
    {

        // Only register a "hit" on the foreground layer
        LayerMask myLayerMask = 1 << 9;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0), Mathf.Infinity, myLayerMask);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * speed;

        // Turn around when "wall" is reached
        if (hit.distance < 0.7f)
        {
            FlipX();
        }
    }

    void FlipX()
    {
        if (xMoveDirection > 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            xMoveDirection = -1;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            xMoveDirection = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Prevent collision with the player

        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<CircleCollider2D>());
        }
    }
}
