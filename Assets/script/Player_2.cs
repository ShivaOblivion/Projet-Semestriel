using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
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
        ;
    }
   
    // Move fonction
    void Move()
    {
        horizontalMove = playerSpeed * Input.GetAxis("Horizontal");
        Vector2 vel = rb.velocity;
        vel.x = horizontalMove;
        rb.velocity = vel;
        

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

