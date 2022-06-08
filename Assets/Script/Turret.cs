using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float turretHP = 10f;
    private float spawnRate = 3f;
    private float elapsedTimes = 0f;

    void Update()
    {
        launchBullet();
        checkHP();
    }
    void launchBullet () {
        elapsedTimes += Time.deltaTime;
        if (spawnRate <= elapsedTimes) {
            elapsedTimes = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0,1,0), transform.rotation);
        }
    }
    void checkHP () {
        if (turretHP <= 0) {//»ç¸ÁÃ³¸®
            Destroy(gameObject);
        }
    }
}
