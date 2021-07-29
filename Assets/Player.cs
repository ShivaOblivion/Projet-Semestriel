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
    public float dachSpeed;
    private float dachTime;
    public float StartDachTime;
    private int direction;
    private bool boosting;
    public float boostSpeed;
    public float boostingTime;
    private float SpeedInitial;
    private float boostTimeur;
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
        dachSpeed = StartDachTime;
    }
   
    // Move fonction
    void Move()
    {
        horizontalMove = playerSpeed * Input.GetAxis("Horizontal");
        Vector2 vel = rb.velocity;
        vel.x = horizontalMove;
        rb.velocity = vel;
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.X))
        {
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)&& Input.GetKeyDown(KeyCode.X))
        {
            direction = 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)&& Input.GetKeyDown(KeyCode.X))
        {
            direction = 3;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)&& Input.GetKeyDown(KeyCode.X))
        {
            direction = 4;

        }
        else
        {
            if (dachTime<=0)
            {
                direction = 0;
                dachTime = StartDachTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dachTime -= Time.deltaTime;
                if (direction==1)
                {
                    rb.velocity = Vector2.left * dachSpeed;
                }
                else if (direction==2)
                {
                    rb.velocity = Vector2.right * dachSpeed;
                }
                else if (direction ==3)
                {
                    rb.velocity = Vector2.up * dachSpeed;
                }
                else if (direction == 4)
                {
                    rb.velocity = Vector2.down * dachSpeed;
                }
            }
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
            Debug.Log("jetPackJumpForce");
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

