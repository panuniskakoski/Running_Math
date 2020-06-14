using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    public Animator animator;


    float horizontalMove = 0f;
    bool jump = false;
    bool interaction = false;

    // Update is called once per frame
    void Update()
    {
        interaction = false;

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButton("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    
    void FixedUpdate() {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        interaction = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

}
