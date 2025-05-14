using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed, jumpForce;
    private float horizontalInput;
    private SpriteRenderer sp;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sp=GetComponent<SpriteRenderer>();

    }
    
    private void Walk(){
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(horizontalInput*speed*Time.deltaTime, 0));
        SpriteFlip(horizontalInput);
    }

    private void Jump(){
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f){
            rb.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
        }
    }

    private void SpriteFlip(float horizontalInput){
        if (horizontalInput > 0) sp.flipX = false;
        else if (horizontalInput < 0) sp.flipX = true;
    }
    void Update()
    {
        Walk();
        Jump();
    }
}






