using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    public Transform enemyFirePoint;
    public GameObject bulletPrefab;
    //public bool isEnemy;

    void Start()
    {

        StartCoroutine(ShootDelay());
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }*/

    void Shoot()
    {
        Instantiate(bulletPrefab, enemyFirePoint.position, enemyFirePoint.rotation);
    }

    private IEnumerator ShootDelay()
    {
        int rnd = Random.Range(1, 4);
        yield return new WaitForSeconds(rnd);
        Shoot();
        StartCoroutine(ShootDelay());
    }

}
