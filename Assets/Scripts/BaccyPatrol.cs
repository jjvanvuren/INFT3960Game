using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sources:
// https://www.youtube.com/watch?v=-mrGHaAdX8M
// https://www.youtube.com/watch?v=aRxuKoJH9Y0

public class BaccyPatrol : MonoBehaviour
{
    public float speed;
    public Transform EdgeCheck;
    public Transform WallCheck;

    private int xMoveDirection = 1;

    // Only register a "hit" on the foreground layer
    LayerMask myLayerMask = 1 << 9;

    private void Update()
    {
        RaycastHit2D hitWall = Physics2D.Raycast(WallCheck.position, new Vector2(xMoveDirection, 0), Mathf.Infinity, myLayerMask);
        RaycastHit2D hitEdge = Physics2D.Raycast(EdgeCheck.position, new Vector2(0, -1), 1f, myLayerMask);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * speed;

        // Turn around when "wall" is reached
        if (hitWall.distance > 0 && hitWall.distance < 0.3)
        {
            FlipX();
        }
        
        if (!hitEdge)
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
