using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int scoreValue = 10;  // amount if score recieved on enemies death
    public GameObject deathEffect;     // downloaded sprite effect

    public void TakeDamage (int damage)  // takedamage will be accessible in bullet script
    {
        health -= damage;

        if (health <= 0)
        {
            Die();    // Die function
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        GameManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
