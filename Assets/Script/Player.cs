using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D characterRigid;
    public GameObject turretPrefab;
    public float characterSpeed = 5f;
    private float coolTime = 1f;
    private float elapsedTimes = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        buildTurret();
    }

    void Move()
    {
        //谅快 捞悼
        float x = Input.GetAxis("Horizontal");
        Vector2 vec = new Vector2();
        vec += new Vector2(x * characterSpeed, characterRigid.velocity.y);
        characterRigid.velocity = vec;     
    }
    void buildTurret()
    {
        elapsedTimes += Time.deltaTime;
        if (Input.GetKeyDown("space"))
        {
            if (coolTime <= elapsedTimes)
            {
                elapsedTimes = 0f;
                //鸥况 积己
                GameObject turret = Instantiate(turretPrefab,transform.position,transform.rotation);

            }
        }
    }
}
