using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source
// https://www.youtube.com/watch?v=aRxuKoJH9Y0

// https://www.youtube.com/watch?v=-mrGHaAdX8M

public class BaccyWallPatrol : MonoBehaviour
{
    public float speed;
    public int xMoveDirection;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * speed;

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
}
