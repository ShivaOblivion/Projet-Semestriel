using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Moveset_test : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 velocity = Vector3.zero;
    public Rigidbody2D rb;
    public float jumpForce;
    private float TimeSinceJump = 6.0f;
    public bool isJumping = false;
    private float gravity;



    void start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    // calcul du mouve
    void Update()
    {
        isJumping = false;

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(horizontalMovement, 0);
        if (!isJumping)
        {
            gravity += 0.3f;
            gravity = Mathf.Clamp(gravity, 0f, 150f);
            rb.AddForce(new Vector2(0f, -gravity));
        }

        Debug.Log(gravity);
        if (Input.GetButtonDown("Jump"))
        {
            {
                gravity = 0;
                rb.AddForce(new Vector2(0f, jumpForce));
                Debug.Log(1);
                isJumping = true;
            }
        }


    }


}