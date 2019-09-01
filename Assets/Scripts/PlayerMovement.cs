using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 20f;

    bool jump = false;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {

        // Check if Run button is held
        if (Input.GetButtonDown("Run"))
        {
            runSpeed *= 2f;
            anim.SetBool("IsRunning", true);
        }
        else if (Input.GetButtonUp("Run"))
        {
            runSpeed = 20f;
            anim.SetBool("IsRunning", false);
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }
    }

    private void FixedUpdate()
    {
        // Move Ery
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        anim.SetBool("IsJumping", false);
    }

}
