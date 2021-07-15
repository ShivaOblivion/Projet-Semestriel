using System.Collections;
using UnityEngine;

public class test_mouv : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 velocity = Vector3.zero;
    public Rigidbody2D rb;
    public float jumpForce;
    private float TimeSinceJump = 6.0f;
    
    
    
    
    
    void start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    
    // calcul du mouve
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(horizontalMovement, 0);
    }
    
}
  