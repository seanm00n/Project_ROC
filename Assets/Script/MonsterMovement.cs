using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Rigidbody2D monsterRigid;
    public int monsterSpeed = 0;
    private bool isColl = false;

    void Start()
    {
        
        
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (!isColl)//충돌 상태가 아닐 시에만 
        {
            Vector2 vec = new Vector2(-monsterSpeed, monsterRigid.velocity.y);
            monsterRigid.velocity = vec;
        }   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Player" && 
            GetComponent<Transform>().position.x < collision.transform.position.x)
        {
            Debug.Log(string.Format("Monster: Enemy on Right"));
            isColl = true;
        }
        else if(collision.gameObject.tag == "Player" &&
            GetComponent<Transform>().position.x > collision.transform.position.x)
        {
            Debug.Log(string.Format("Monster: Enemy on Left"));
            isColl = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isColl = false;
    }
}
