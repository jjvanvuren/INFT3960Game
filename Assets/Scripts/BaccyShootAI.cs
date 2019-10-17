using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaccyShootAI : MonoBehaviour
{
    public GameObject spit;
    public Transform player, spitPoint;
    public float sightRange;
    public float spitInterval = 1f;

    private bool lookRight = true;
    private float spitTimer = 0;
    private RaycastHit2D seeForeground;
    private RaycastHit2D seePlayer;
    private Vector2 rayDirection;

    // Only Register for player layer
    LayerMask playerMask = 1 << 10;
    LayerMask foregroundMask = 1 << 9;

    // Update is called once per frame
    void Update()
    {
        // Set ray direction to player location
        rayDirection = player.transform.position - transform.position;
        rayDirection.Normalize();

        // Raycast for foreground and player
        seeForeground = Physics2D.Raycast(transform.position, rayDirection, sightRange, foregroundMask);
        seePlayer = Physics2D.Raycast(transform.position, rayDirection, sightRange, playerMask);


        if (seePlayer && !seeForeground) // Only if player spotted
        {
            FlipX();
            Spit();
            
        }
    }

    private void Spit()
    {
        
        Vector2 direction;

        spitTimer += Time.deltaTime;

        if (spitTimer >= spitInterval)
        {
            direction = player.transform.position - transform.position;
            direction.Normalize();

            Instantiate(spit, spitPoint.transform.position, spitPoint.transform.rotation);

            spitTimer = 0;
        }
    }
        
    private void FlipX()
    {
        if (rayDirection.x < 0f && lookRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            lookRight = false;
        }
        else if (rayDirection.x > 0f && !lookRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            lookRight = true;
        }
    }
}
