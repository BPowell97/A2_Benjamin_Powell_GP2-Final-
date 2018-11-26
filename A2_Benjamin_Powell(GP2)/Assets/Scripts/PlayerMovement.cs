using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
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

    public GameObject winPanel;
    public GameObject losePanel;
    //private bool crouch;

    private bool facingRight = true;

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

        /*if (Input.GetKeyDown(KeyCode.F))
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }*/
    }

    /*public void OnCrouching (bool isCrouching)
    {
        
        animator.SetBool("IsCrouching", isCrouching);
    }*/

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

    private void Flip()
    {
        facingRight = !facingRight;
        transform.eulerAngles = new Vector3(0, -180, 0);
        /*if (facingRight)
        {
            facingRight = false;
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        //transform.eulerAngles = new Vector3(0, -180, 0);
        else
        {
            facingRight = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }*/
    }

    void Finish()
    {
        myRigidbody.bodyType = RigidbodyType2D.Static;
        winPanel.SetActive(true);
        Destroy(gameObject);
    }

    void Lose()
    {
        myRigidbody.bodyType = RigidbodyType2D.Static;
        losePanel.SetActive(true);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Portal")
        {
            Finish();
        }

        if (col.tag == "Saw")
        {
            Lose();
        }
    }
}
