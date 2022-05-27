using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRigid;
    public int bulletSpeed = 0;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector2 vec = new Vector2(bulletSpeed, 0);
        bulletRigid.velocity = vec;
    }
}
