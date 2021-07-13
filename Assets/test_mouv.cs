using System.Collections;
using UnityEngine;

public class test_mouv : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 velocity = Vector3.zero;
    public Rigidbody2D rb;
    
    // calcul du mouve
    void fixUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
}
