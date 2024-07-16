using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private bool isRunning;
    [SerializeField] private bool isJumping;
    [SerializeField] private float horizontal;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rb;


    private bool isFacingRight = true;

    
    private Animator anim;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal != 0 && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))){
            anim.SetBool("isRunning", true);
        }else{
            anim.SetBool("isRunning", false);
        }

        if(Input.GetKey(KeyCode.R)){
            transform.position = new Vector3(-7.5f, 2.5f, 0);
        }
        if(Input.GetKey(KeyCode.T)){
            Debug.Log(groundCheck.position);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(Input.GetButtonUp("Jump")){
            if(rb.velocity.y > 0){
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
       

        Flip();
    }

    private void FixedUpdate(){
        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        
    }

    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip(){
        if(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")){
            Destroy(transform.gameObject);
        }
    }
}
