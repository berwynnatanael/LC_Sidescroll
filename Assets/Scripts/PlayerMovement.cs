using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed, jumpForce;
    private float horizontalInput;
    private SpriteRenderer sp;
    private Animator animator;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sp=GetComponent<SpriteRenderer>();
        animator=GetComponent<Animator>();

    }
    
    private void PlayAnimation(string animationTriggerName){
        animator.SetTrigger(animationTriggerName);
    }
    
    private void Walk(){
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(horizontalInput*speed*Time.deltaTime, 0));
        SpriteFlip(horizontalInput);
        if (horizontalInput == 0) animator.Play("Idle");
    }

    private void Jump(){
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f){
            rb.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
            PlayAnimation("goJump");
        }
    }

    private void SpriteFlip(float horizontalInput){
        if (horizontalInput > 0){
            sp.flipX = false;
            PlayAnimation("goWalk");
        } 
        else if (horizontalInput < 0){
            sp.flipX = true;
            PlayAnimation("goWalk");
        } 
    }
    void Update()
    {
        Walk();
        Jump();
    }
}






