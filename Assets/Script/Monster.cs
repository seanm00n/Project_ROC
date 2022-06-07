using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Rigidbody2D monsterRigid;
    public GameObject GoldPrefab;
    public Animator animator;
    public float monsterSpeed = 5f;
    public float monsterHP = 10f;
    public float monsterAP = 2f;
    bool isEncounter = false;
    //string STATE; //상태 계속 검사해서 바뀌면 바로 SetBool(STATE, false) 해주기
    void Start()
    {
        STATE = "Idle";
    }
    void Update()
    {
        Move();//이동
        checkHP();
    }

    void Move(){
        if (!isEncounter){
            Vector2 vec = new Vector2(-monsterSpeed, monsterRigid.velocity.y);
            monsterRigid.velocity = vec;
        }
    }
    void checkHP () {

        if (monsterHP <= 0) {//사망처리
            GetComponent<Animator>().SetBool("Death", true);
            //STATE = "Death";
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death") &&
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
                Destroy(gameObject);
                GameObject gold = Instantiate(GoldPrefab,transform.position, transform.rotation);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "attackCollider") {
            Hit();
        }
        if (collision.gameObject.tag == "Player" || 
            collision.gameObject.tag == "Turret" || 
            collision.gameObject.tag == "Barricade" ||
            collision.gameObject.tag == "Nexus") {
            Attack();
        }
    }
    private void OnCollisionExit2D (Collision2D collision) {
        isEncounter = false;
    }
    void Hit () {
        isEncounter = true;
        GetComponent<Animator>().SetBool("Hit", true);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
            GetComponent<Animator>().SetBool("Hit", false);
            isEncounter = false;
        }
    }
    void Attack () {
        isEncounter = true;
        GetComponent<Animator>().SetBool("Attack", true);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
            GetComponent<Animator>().SetBool("Attack", false);
            isEncounter = false;
        }
    }
}
