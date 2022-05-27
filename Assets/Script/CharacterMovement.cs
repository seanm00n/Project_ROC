using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D characterRigid;
    public int characterSpeed = 0;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        //ÁÂ¿ì ÀÌµ¿
        float x = Input.GetAxis("Horizontal");
        Vector2 vec = new Vector2();
        vec += new Vector2(x * characterSpeed, characterRigid.velocity.y);
        characterRigid.velocity = vec;     
    }

}
