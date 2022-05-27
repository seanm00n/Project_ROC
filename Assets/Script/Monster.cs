using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Rigidbody2D monsterRigid;
    public int monsterSpeed = 0;
    private bool isColl = false;
    private int monsterHP = 3;
    float timer;
    int waitingTime;
    void Start()
    {
        timer = 0.0f;
        waitingTime = 2;
    }
    void Update()
    {
        Move();//이동
        hpLog();//HP출력
        checkDie();//사망시 삭제

    }
    void Move()
    {
        if (!isColl)//충돌 상태가 아닐 시에만 
        {
            Vector2 vec = new Vector2(-monsterSpeed, monsterRigid.velocity.y);
            monsterRigid.velocity = vec;
        }   
    }
    void hpLog()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            timer = 0;
            Debug.Log("Monster HP : " + monsterHP);
            //2초마다 생성, 2초 뒤 삭제
        }
    }
    void checkDie()
    {
        if (monsterHP < 0)
        {
            Destroy(this.gameObject);
            Debug.Log("MonsterDie");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //캐릭터와의 충돌 처리
        if (collision.gameObject.tag == "Player" &&
            GetComponent<Transform>().position.x < collision.transform.position.x)
        {
            Debug.Log(string.Format("Monster: Enemy on Right"));
            isColl = true;
        }
        else if (collision.gameObject.tag == "Player" &&
            GetComponent<Transform>().position.x > collision.transform.position.x)
        {
            Debug.Log(string.Format("Monster: Enemy on Left"));
            isColl = true;
        }

        if(collision.gameObject.tag == "Bullet")
        {
            monsterHP -= 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isColl = false;
    }
}
