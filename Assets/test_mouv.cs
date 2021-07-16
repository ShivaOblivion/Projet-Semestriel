using System.Collections;
using UnityEngine;

public class test_mouv : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 velocity = Vector3.zero;
    public Rigidbody2D rb;
    public float jumpForce;
    private float TimeSinceJump = 6.0f;
    public bool isJumping = false;
    
    
    
    
    void start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    
    // calcul du mouve
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(horizontalMovement, 0);


        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce));
        isJumping = false;
    }
}