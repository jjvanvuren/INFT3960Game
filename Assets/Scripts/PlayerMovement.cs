using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source
// https://www.youtube.com/watch?v=dwcT-Dch0bA

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float speed;
    bool jump = false;
    public Animator anim;
    private bool isGrounded;
    public Material originalMat;

    // Update is called once per frame
    void Update()
    {

        

        // Check if Run button is held
        if (Input.GetButtonDown("Run") && isGrounded)
        {
            speed *= 2f;
            anim.SetBool("IsRunning", true);
        }
        else if (Input.GetButtonUp("Run"))
        {
            speed = 20f;
            anim.SetBool("IsRunning", false);
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        anim.SetBool("IsGrounded", isGrounded);

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("IsGrounded", false);
            jump = true;
        }

        // Add transparency when player is invulnerable
        if (GetComponent<CharacterController2D>().invulnerabilityCount > 0 && GetComponent<CharacterController2D>().CharacterLives > 0)
        {
            //GetComponent<SpriteRenderer>().material = invulnerableMat;
            GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 150);

        }
        else
        {
            GetComponent<SpriteRenderer>().material = originalMat;
        }
    }

    private void FixedUpdate()
    {
        // Check if Ery is grounded
        isGrounded = controller.m_Grounded;

        // Move Ery
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);

        jump = false;
    }
}
