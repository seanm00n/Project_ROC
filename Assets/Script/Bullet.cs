using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRigid;
    public float bulletSpeed = 8f;
    
    void Start()
    {
        bulletRigid = GetComponent<Rigidbody2D>();
        bulletRigid.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector2 vec = new Vector2(bulletSpeed, 0);
        bulletRigid.velocity = vec;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.GetComponent<Monster>();
        if(collision.tag == "Monster")
        {
            if (monster != null)
            {
                //monster.Hit();
            }
        }
    }
}
