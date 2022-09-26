using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed, climbSpeed;
    public float jumpPower;
    public Rigidbody2D rb;

    Collider2D playerCollider;

    public Transform groundCheck, LeftCheck, RightCheck;
    public float groundCheckRadius, leftCheckRadius, RightCheckRadius;
    public Vector2 leftCheckMeasurements, rightCheckMeasurements;
    public bool isGrounded, touchesLeft, touchesRight;
    
    public bool isClimbing;
    public bool canClimb;
    public GameObject currentLadder;

    public bool onBottom;

    Dialogue dialogue;

    public PossibleLines[] startUpDialogue;
    public Conversation startUpDialogue1;

    public Animator playerAnimator;
    public Transform playerAnimatorObject;

    public bool interacting;
    public bool reading;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        dialogue = FindObjectOfType<Dialogue>();

        dialogue.InitiateNewConversation(startUpDialogue1);
        reading = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireCube(LeftCheck.position, new Vector3(leftCheckMeasurements.x, leftCheckMeasurements.y));
        Gizmos.DrawWireCube(RightCheck.position, new Vector3(rightCheckMeasurements.x, rightCheckMeasurements.y));

    }

    private void Update()
    {
        LogicUpdate();
        dialogue.MoveText();
    }

    private void FixedUpdate()
    {
        PhysicsUpdate();
    }

    public void LogicUpdate()
    {
        //if (Input.GetAxisRaw("Horizontal") != 0)
        //{
        //    transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y);
        //    //rb.MovePosition(new Vector3(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y));
        //}
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius);
        if (isGrounded && Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius).isTrigger)
        {
            isGrounded = false;
        }

        touchesLeft = Physics2D.OverlapBox(LeftCheck.position, leftCheckMeasurements, 0);
        if (touchesLeft && Physics2D.OverlapBox(LeftCheck.position, leftCheckMeasurements, 0).isTrigger)
        {
            touchesLeft = false;
        }

        touchesRight = Physics2D.OverlapBox(RightCheck.position, rightCheckMeasurements, 0);
        if (touchesRight && Physics2D.OverlapBox(RightCheck.position, rightCheckMeasurements, 0).isTrigger)
        {
            touchesRight = false;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            dialogue.ContinueText();
        }
        playerAnimator.SetBool("Interacting", interacting);
    }

    public void PhysicsUpdate()
    {
        //transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y);
        //rb.MovePosition(new Vector3(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y));
        //rb.AddForce(new Vector2(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y) - new Vector2(transform.position.x, transform.position.y), ForceMode2D.Impulse);
        if (!interacting && !reading)
        {
            float horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;

            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                playerAnimator.SetBool("Running", false);
            }

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                playerAnimator.SetBool("Running", true);
                playerAnimator.SetBool("Left", false);
                playerAnimatorObject.localScale = new Vector3(1, 1, 1);
            }

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                playerAnimator.SetBool("Running", true);
                playerAnimator.SetBool("Left", true);
                playerAnimatorObject.localScale = new Vector3(-1, 1, 1);
            }

            if ((touchesLeft && Input.GetAxisRaw("Horizontal") < 0) || (touchesRight && Input.GetAxisRaw("Horizontal") > 0))
            {
                Debug.Log("TOUCHESSIDE");
                horizontalMovement = 0;
            }


            rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);

            if (canClimb)
            {
                if (Input.GetAxis("Vertical") != 0)
                {
                    isClimbing = true;
                }
                //ya boy can climb, I just need a distinction between up and down

            }
            else
            {
                isClimbing = false;
                playerCollider.isTrigger = false;
                rb.gravityScale = 1;
            }

            if (isClimbing)
            {
                rb.gravityScale = 0;
                playerCollider.isTrigger = true;
                if (onBottom && Input.GetAxisRaw("Vertical") < 0)
                {
                    rb.velocity = new Vector2(horizontalMovement, 0);
                }
                else
                {
                    rb.velocity = new Vector2(horizontalMovement, Input.GetAxisRaw("Vertical") * climbSpeed);
                }
            }
        }

        playerAnimator.SetBool("Climbing", isClimbing);
    }
}
