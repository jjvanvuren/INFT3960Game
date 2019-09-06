using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source
// https://www.youtube.com/watch?v=aRxuKoJH9Y0

public class BaccyPlatPatrol : MonoBehaviour
{
    public float speed;
    public int xMoveDirection;
    public Transform EdgeCheck;


    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * speed;

        RaycastHit2D hit = Physics2D.Raycast(EdgeCheck.position, Vector2.down, 0.2f);
        
        if (!hit)
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
