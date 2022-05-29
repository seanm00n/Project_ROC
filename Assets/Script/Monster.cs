using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Rigidbody2D monsterRigid;
    public float monsterSpeed = 5f;
    private bool isEncounter = false;
    void Start()
    {

    }
    void Update()
    {
        Move();//¿Ãµø
        
    }

    void Move()
    {
        if (!isEncounter)
        {
            Vector2 vec = new Vector2(-monsterSpeed, monsterRigid.velocity.y);
            monsterRigid.velocity = vec;
        }
        
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || 
            collision.gameObject.tag == "Turret")
        {
            isEncounter = true;
        }
        else
        {
            isEncounter = false;
        }
        
    }
}
