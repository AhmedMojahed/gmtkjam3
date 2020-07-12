using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float jumpSpeed = 200f;
    [SerializeField] Canvas pauseCanvas;

    Rigidbody2D myRigidbody;
    Animator myAnimator;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        pauseCanvas.enabled = false;
    }

    void Update()
    {
        Run();
        Jump();
        PauseMenu();
    }

    private void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.enabled = true;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed * Time.deltaTime);
            myRigidbody.velocity += jumpVelocityToAdd;

            //Animation
            bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("Jumping", playerHasVerticalSpeed);
        }
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * moveSpeed * Time.deltaTime, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        //Animation
        bool playerHasHorizaontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizaontalSpeed);

    }

    public void EnablePauseCanvas(bool enabled)
    {
        pauseCanvas.enabled = enabled;
    }
}
