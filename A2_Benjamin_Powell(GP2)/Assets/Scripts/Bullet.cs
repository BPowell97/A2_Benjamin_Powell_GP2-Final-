using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    public int playerDamage = 10;

	// Use this for initialization
	void Start ()
    {
        rb.velocity = transform.right * speed;
	}

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

        Player player = hitInfo.GetComponent<Player>(); //player shooting mechanics not set up
        if (player != null)
        {
            player.PlayerTakeDamage(damage);
        }
        Destroy(gameObject);
        
    }

}
