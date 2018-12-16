using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int playerDamage = 10;

    // Use this for initialization
    void Start ()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>(); //player shooting mechanics not set up
        if (player != null)
        {
            player.PlayerTakeDamage(playerDamage);
        }
        Destroy(gameObject);
    }

}
