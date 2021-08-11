using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Rigidbody2D rb;
    public float StartDachTime;
    private float dachTime;
    public float dachSpeed;
    private int direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dachTime = StartDachTime;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.X))
        {
            direction = 1;
            Debug.Log("dach");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)&& Input.GetKeyDown(KeyCode.X))
        {
            direction = 2;
            Debug.Log("dach");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)&& Input.GetKeyDown(KeyCode.X))
        {
            direction = 3;
            Debug.Log("dach");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)&& Input.GetKeyDown(KeyCode.X))
        {
            direction = 4;
            Debug.Log("dach");

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
    }
}
