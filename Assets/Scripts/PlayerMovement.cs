using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 20f;

    bool jump = false;

    // Update is called once per frame
    void Update()
    {

        // Check if Run button is held
        if (Input.GetButtonDown("Run"))
        {
            runSpeed *= 2f;
        }
        else if (Input.GetButtonUp("Run"))
        {
            runSpeed = 20f;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        // Move Ery
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
