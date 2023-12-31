using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerJump : MonoBehaviour
{
    [Header("Jump Details")]
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;
    public bool doubleJump; //temporariamente publico
    private bool doubleJumped;

    [Header("Ground Details")]
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround;
    public bool grounded;
    
    [Header("Components")]
    private Rigidbody2D rb;
    private Animator myAnimator;

    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
    }

    private void Update ()
    {
        //what it means to be grounded
        grounded = Physics2D.OverlapCircle(groundcheck.position, radOCircle, whatIsGround);

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            doubleJumped = false;
            myAnimator.ResetTrigger("jump");
            myAnimator.SetBool("falling", false);
        }
        
        //if press the jump button
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            stoppedJumping = false;

            //tell the animator to play jump anim
            myAnimator.SetTrigger("jump");
        }

        //if hold the jump button
        if(Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
            myAnimator.SetTrigger("jump");
            if (jumpTimeCounter < 0)
                stoppedJumping = true;
        }

        //if release the jump button
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            myAnimator.ResetTrigger("jump");
        }

        //double jump
        if (Input.GetButtonDown("Jump") && !grounded && doubleJump && !doubleJumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce*1.25f);
            myAnimator.SetBool("double jump", true);
            doubleJumped = true;
        }

        if (rb.velocity.y < 0)
        {
            myAnimator.SetBool("falling", true);
            myAnimator.SetBool("double jump", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundcheck.position, radOCircle);
    }

    private void FixedUpdate()
    {
        HandleLayers();
    }

    private void HandleLayers()
    {
        if (!grounded)
        {
            myAnimator.SetLayerWeight(2, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(2, 0);
        }
    }
}
