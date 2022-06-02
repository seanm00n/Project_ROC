using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float turretHP = 10f;
    private float spawnRate = 3f;
    private float elapsedTimes = 0f;

    void Start()
    {

    }
    void Update()
    {
        elapsedTimes += Time.deltaTime;
        if (spawnRate <= elapsedTimes)
        {
            elapsedTimes = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //bullet.transform.LookAt(target);
        }
    }
}
