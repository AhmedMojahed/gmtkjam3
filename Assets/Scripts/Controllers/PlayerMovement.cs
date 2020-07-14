using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletController bulletPrefab;
    public Animator animator;
    public CharacterController2D controller;
    [SerializeField]float moveSpeed = 40f;
    float horizontalMove = 0;
    bool jump= false;
    bool attack = false;


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
        if(Input.GetKeyDown(KeyCode.F))
        {
            //attack animations
            attack = true;
            animator.SetBool("isAttacking", attack);
            Debug.Log("Shooting " + attack);
            FireBullet();
        }
       else if(Input.GetKeyUp(KeyCode.F))
        {
            attack = false;
            animator.SetBool("isAttacking", attack);
        }

    }
    private void FireBullet()
    {
        Vector2 spawnPosition = transform.position;
        BulletController bullet =
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        bullet.bulletSpeed = 2;
        bullet.bulletDirection = Vector2.right;
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", jump);
        Debug.Log("Onland Movement" +  animator.GetBool("isJumping"));
        
    }
    private void FixedUpdate()
    {
        // move character

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump) ;
        jump = false;

    }
    // Update is called once per frame
}
