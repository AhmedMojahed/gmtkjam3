using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;
    [SerializeField]float moveSpeed = 40f;
    float horizontalMove = 0;
    bool jump= false;


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            Debug.Log("before set " + animator.GetBool("isJumping"));
            animator.SetBool("isJumping", jump);
            Debug.Log("after set " + animator.GetBool("isJumping"));
        }

    }
   
    public void OnLanding()
    {
        animator.SetBool("isJumping", jump);
        Debug.Log("Onland " +  animator.GetBool("isJumping"));
    }
    private void FixedUpdate()
    {
        // move character

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump) ;
        jump = false;

    }
    // Update is called once per frame
}
