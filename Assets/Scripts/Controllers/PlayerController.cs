using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;
    [SerializeField] float moveSpeed = 40f;
    float horizontalMove = 0;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", jump);
        }
       
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", jump);
    }
    private void FixedUpdate()
    {
        // move character

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
    
}
