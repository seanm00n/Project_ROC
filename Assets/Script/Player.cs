using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D charRigid;//본인 rigid
    public GameObject turretPrefab;//포탑
    public float charSpeed = 5f;
    public float charAP = 4f;
    public float charHP = 20f;
    public float charFixP = 2f;
    private float elapsedTimes = 0f;
    
    void Update()
    {
        Move();
        buildTurret();
        Attack();
    }

    void Move()
    {
        float input = Input.GetAxisRaw("Horizontal");
        Vector3 vel = new Vector3(0, charRigid.velocity.y, 0);
        
        
        if (input != 0)//입력 있을 때
        {
            //Run -> true
            GetComponent<Animator>().SetBool("Run", true);

            //rotate
            Vector3 rotate = new Vector3();
            const int scaleX = 2;
            rotate = transform.localScale;
            rotate.x = input * scaleX;
            transform.localScale = rotate;

            //adjust vel
            vel += new Vector3(input * charSpeed, charRigid.velocity.y);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run",false);
        }
        //add vel
        charRigid.velocity = vel;

    }
    void buildTurret()
    {
        elapsedTimes += Time.deltaTime;
        if (Input.GetKeyDown("space"))
        {
            GameObject turret = Instantiate(turretPrefab,transform.position,transform.rotation);
        }
    }
    void Attack () {
        if (Input.GetKeyDown(KeyCode.Z)) {
            GetComponent<Animator>().SetBool("Throw",true);
        }
        //시간이 지나면 끝나도록
        //GetComponent<Animator>().SetBool("Throw", false);
    }
    void Throw () {

    }
}
