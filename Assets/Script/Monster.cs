using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Rigidbody2D monsterRigid;
    public Animator animator;
    public float monsterSpeed = 5f;
    public float monsterHP = 10f;
    public float monsterAP = 2f;
    bool isEncounter = false;
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
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death") &&
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "attackCollider") {
            Hit();
        }
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Turret" || collision.gameObject.tag == "Barricade") {
            Attack();
        }
    }
    void Hit () {
        GetComponent<Animator>().SetBool("Hit", true);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
            GetComponent<Animator>().SetBool("Hit", false);
        }
    }
    void Attack () {
        GetComponent<Animator>().SetBool("Attack", true);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
            GetComponent<Animator>().SetBool("Attack", false);
        }
    }
}
