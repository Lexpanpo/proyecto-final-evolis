using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGounded;
    public Transform position;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    private float jumpTImeCounter;
    public float jumpTime;
    private bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    private void Update()
    {
        isGounded = Physics2D.OverlapCircle(position.position, checkRadius, whatIsGrounded);
        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if(isGounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTImeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTImeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTImeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
