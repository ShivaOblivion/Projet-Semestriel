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
    private float yJump;


    void start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    // calcul du mouve
    void Update()
    {
        isJumping = false;

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(horizontalMovement, yJump);
        if (Input.GetButtonDown("Jump"))
        {
            {
                yJump = jumpForce;
            }
        }
        else
        {
            yJump = 0;
        }


    }


}