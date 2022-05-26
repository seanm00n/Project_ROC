using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Rigidbody2D rigid;
    float x = Input.GetAxis("Horizontal");
    public int speed = 10;
    
    void Start()
    {
        
        
    }
    void Update()
    {
        Vector2 vector = new Vector2(x * speed, rigid.velocity.y);
        rigid.velocity = vector;
    }
}
