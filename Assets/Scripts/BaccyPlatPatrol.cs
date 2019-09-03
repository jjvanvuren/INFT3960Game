using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaccyPlatPatrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public int xMoveDirection;
    public Transform EdgeCheck;


    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * speed;

        RaycastHit2D hit = Physics2D.Raycast(EdgeCheck.position, Vector2.down, distance);
        
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
