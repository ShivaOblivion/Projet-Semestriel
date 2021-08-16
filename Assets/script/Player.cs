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
    private bool boosting;
    public float boostSpeed;
    public float boostingTime;
    private float SpeedInitial;
    private float boostTimeur;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpeedInitial = playerSpeed;
        boosting = false;
        boostTimeur = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        //Filp
        Flip(rb.velocity.x);
    }
   
    // Move fonction
    void Move()
    {
        horizontalMove = playerSpeed * Input.GetAxis("Horizontal");
        Vector2 vel = rb.velocity;
        vel.x = horizontalMove;
        rb.velocity = vel;
        
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        

        if (boosting)
        {
            boostTimeur += Time.deltaTime;
            
            if (boostTimeur >=boostingTime)
            {
                playerSpeed = SpeedInitial;
                boostingTime = 0;
                boosting = true;

            }
        }
        
    }
    //buff debuff 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "speedBoost")
        {
            Debug.Log("speedBoost");
            boosting = true;
            playerSpeed += boostSpeed;
            Destroy(other.gameObject);
        }
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
        else if (Input.GetButtonDown("Jump"))
        {
            Vector2 vel = rb.velocity;
            vel.y = jetPackJumpForce;
            rb.velocity = vel;
            Debug.Log("jetPackJump");

        }
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetBool("isJumping",true);
            
        } 
        else if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJetPackJumping", true);
        }
        else
        {
            animator.SetBool("isJumping",false);
            animator.SetBool("isJetPackJumping", false);
        }

        if (IsGrounded())
        {
            animator.SetBool("isFlying",false);
        }
        else
        {
            animator.SetBool("isFlying",true);
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
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}


