using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source
// https://www.youtube.com/watch?v=aRxuKoJH9Y0

public class BaccyAI : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool isMovingRight = true;
    public Transform groundDetection;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(!groundInfo.collider)
        {
            if (isMovingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                isMovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isMovingRight = true;
            }
        }
    }
}
