using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Rigidbody2D monsterRigid;
    public float monsterSpeed = 5f;
    public float monsterHP = 10f;
    public float monsterAP = 2f;
    private bool isEncounter = false;
    
    void Update()
    {
        Move();//이동
        checkHP();
    }

    void Move()
    {
        if (!isEncounter)
        {
            Vector2 vec = new Vector2(-monsterSpeed, monsterRigid.velocity.y);
            monsterRigid.velocity = vec;
        }
        
    }
    void checkHP () {

        if (monsterHP <= 0) {//사망처리
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        switch (collision.gameObject.tag) {
            case "Player":
                isEncounter = true;
                break;
            case "Turret":
                isEncounter = true;
                break;
        }
    }
}
