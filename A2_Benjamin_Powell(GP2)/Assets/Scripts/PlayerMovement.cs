﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private bool isGrounded;

    private bool jump;

    //private bool facingRight = true;

    [SerializeField]
    private float jumpForce;


	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleInput();

	}

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        isGrounded = IsGrounded();
    }

    private void ResetValues()
    {
        jump = false;
    }


    private void HandleMovement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);

        //if ((isGrounded && jump) && Input.GetKeyDown(KeyCode.Space))
        {
            //myRigidbody.AddForce(new Vector2(0, jumpForce));
            //jump = true;

            //if (!jump && !isGrounded)
                //jump = true;
        }

        if (jump && isGrounded)
        {
            //isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            jump = false; // stops player from jumping repeatively
        }

        else//(!jump && !isGrounded)
        {
            //jump = true;
            isGrounded = true;
            myRigidbody.AddForce(new Vector2(0, jumpForce * 0));
        }

        /*if (isGrounded && jump)
        {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
        }*/

    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        //Debug.Log(colliders[i].gameObject.name);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    /*private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }*/

}
