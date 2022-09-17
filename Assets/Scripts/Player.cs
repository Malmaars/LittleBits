using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed, climbSpeed;
    public float jumpPower;
    public Rigidbody2D rb;

    public Transform groundCheck;
    public float groundCheckRadius;
    public bool isGrounded;
    
    public bool isClimbing;
    public bool canClimb;
    public GameObject currentLadder;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxisRaw("Horizontal") != 0)
        //{
        //    transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y);
        //    //rb.MovePosition(new Vector3(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y));
        //}
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius);

        if (Input.GetKeyDown(KeyCode.J) && isGrounded)
        {
            //jump
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void FixedUpdate()
    {
            //transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y);
            //rb.MovePosition(new Vector3(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y));
            //rb.AddForce(new Vector2(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y) - new Vector2(transform.position.x, transform.position.y), ForceMode2D.Impulse);
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

        if (canClimb)
        {
            if(Input.GetAxis("Vertical") != 0)
            {
                isClimbing = true;
            }
            //ya boy can climb, I just need a distinction between up and down

        }
        else
        {
            isClimbing = false;
            rb.gravityScale = 1;
        }

        if (isClimbing)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * climbSpeed);
        }
    }
}
