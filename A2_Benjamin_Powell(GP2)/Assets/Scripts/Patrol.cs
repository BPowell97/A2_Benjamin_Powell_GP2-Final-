using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float distance;
    public GameObject enemy;

    private bool movingRight = true;

    public Transform groundDetection; private Vector2 movementDirection;

    void Start()
    {
        enemy = gameObject;
        movementDirection = Vector2.right;
    }


    void Update()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight)
            {
                movingRight = false;
                //movementDirection = Vector2.left;
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else
            {
                movingRight = true;
                //movementDirection = Vector2.right;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

        }
    }
    //void Update()
    //{
    //    transform.Translate(Vector2.right * speed * Time.deltaTime);

    //    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
    //    Debug.DrawRay(groundDetection.position, Vector2.down);
    //    Detection(groundInfo);
    //}

    //private void Detection(RaycastHit2D groundInfo)
    //{
    //    Debug.Log(groundInfo.collider.tag);
    //    if (groundInfo.collider.tag != "Ground")
    //    {
    //        if (movingRight == true)
    //        {
    //            transform.eulerAngles = new Vector3(0, -180, 0);
    //            movingRight = false;
    //        }
    //        else
    //        {
    //            transform.eulerAngles = new Vector3(0, 0, 0);
    //            movingRight = true;
    //        }
    //    }
    //}
}
