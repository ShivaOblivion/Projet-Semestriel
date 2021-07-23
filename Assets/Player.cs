using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float playerSpeed;
    public float jumpForce;
    private float horizontalMove;
    public float distanceCheckGrounded = 0.5f;
    public LayerMask groundLayer;
    public float jetPackJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
   
    // Move fonction
    void Move()
    {
        horizontalMove = playerSpeed * Input.GetAxis("Horizontal");
        Vector2 vel = rb.velocity;
        vel.x = horizontalMove;
        rb.velocity = vel;
    }

    // Jump fonction
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Vector2 vel = rb.velocity;
            vel.y = jumpForce;
            rb.velocity = vel;
            Debug.Log("jump");
        }
    }
    //Grounded_tchek
    private bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distanceCheckGrounded, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
    
}

