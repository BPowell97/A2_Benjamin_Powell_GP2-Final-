using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float distance;
    public GameObject enemy;

    private bool movingRight = true;

    public Transform groundDetection;

    void Start()
    {
        enemy = gameObject;
    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        Detection(groundInfo);
    }

    private void Detection(RaycastHit2D groundInfo)
    {
        if (groundInfo.collider.gameObject.tag == "Ground")
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
