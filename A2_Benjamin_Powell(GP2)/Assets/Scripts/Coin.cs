using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]
    private float floatSpeed = 0.5f;

    [SerializeField]
    private float movementDistance = 0.5f;

    private float startingY;
    private bool isMovingUp = true;

    public int coinValue = 20; //Added score value shen you pickup coin


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        GameManager.Instance.NumCoins++;
        GameManager.Instance.AddScore(coinValue); //Access to GameManager Script
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        startingY = transform.position.y;

        transform.Rotate(transform.up, Random.Range(0f, 360f));

        StartCoroutine(Float());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private IEnumerator Float()
    {
        while (true)
        {
            float newY = transform.position.y + (isMovingUp ? 1 : -1) * 2 * movementDistance * floatSpeed * Time.deltaTime;

            if (newY > startingY + movementDistance)
            {
                newY = startingY + movementDistance;
                isMovingUp = false;
            }

            else if (newY < startingY)
            {
                newY = startingY;
                isMovingUp = true;
            }

            transform.position = new Vector2(transform.position.x, newY);
            yield return 0;
        }
    }


}
