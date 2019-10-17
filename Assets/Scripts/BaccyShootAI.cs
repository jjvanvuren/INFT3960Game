using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaccyShootAI : MonoBehaviour
{
    public GameObject spit;
    public Transform player, spitPoint;

    public bool playerSeen;
    public bool lookRight = true;
    public float distance, sightRange;
    private float spitTimer = 0;

    RaycastHit2D seePlayerLeft;
    RaycastHit2D seePlayerRight;

    // Only Register for player layer
    LayerMask myLayerMask = 1 << 10;

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("Awake", playerSeen);
        //anim.SetBool("LookingRight", lookRight);

        seePlayerLeft = Physics2D.Raycast(transform.position, Vector2.left, 14f, myLayerMask);
        seePlayerRight = Physics2D.Raycast(transform.position, Vector2.right, 14f, myLayerMask);

        FlipX();

        if (seePlayerLeft || seePlayerRight)
        {
            Spit();
        }

    }

    private void Spit()
    {
        float spitInterval = 0.5f;
        GameObject spitClone;
        Vector2 direction;
        float bulletSpeed = 2f;

        spitTimer += Time.deltaTime;

        if (spitTimer >= spitInterval)
        {
            direction = player.transform.position - transform.position;
            direction.Normalize();

            spitClone = Instantiate(spit, spitPoint.transform.position, spitPoint.transform.rotation) as GameObject;
            spitClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            spitTimer = 0;
        }
    }
        

       

    private void FlipX()
    {
        if (seePlayerLeft && lookRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            lookRight = false;
        }
        else if (seePlayerRight && !lookRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            lookRight = true;
        }
    }
}
