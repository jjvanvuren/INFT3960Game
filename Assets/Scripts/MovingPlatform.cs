using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Source for player collision: https://www.youtube.com/watch?v=O6wlIqe2lTA

    public Vector3 velocity;
    public int minPositionY;
    public int maxPositionY;
    public bool changeDirection;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }

    private void FixedUpdate()
    {
        // Move the platform up or down
        if (transform.position.y <= maxPositionY && !changeDirection)
        {

            transform.position += velocity * Time.deltaTime;
        }

        else if (transform.position.y >= minPositionY && changeDirection)
        {

            transform.position -= velocity * Time.deltaTime;
        }


        // Change direction when reaching max or min position
        if (transform.position.y > maxPositionY)
        {
            changeDirection = true;
        }

        else if (transform.position.y < minPositionY)
        {
            changeDirection = false;
        }


    }
}
