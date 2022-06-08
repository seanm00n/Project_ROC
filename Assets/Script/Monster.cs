using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Rigidbody2D monsterRigid;
    public GameObject GoldPrefab;
    public GameObject colliderPrefab;
    public Animator animator;
    public float monsterSpeed = 5f;
    public float monsterHP = 10f;
    public float monsterAP = 2f;
    bool isEncounter = false;

    //string STATE; //���� ��� �˻��ؼ� �ٲ�� �ٷ� SetBool(STATE, false) ���ֱ�
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    void Update()
    {
        Move();//�̵�
        checkHP();
    }

    void Move(){
        if (!isEncounter){
            Vector2 vec = new Vector2(-monsterSpeed, monsterRigid.velocity.y);
            monsterRigid.velocity = vec;
        }
    }
    void checkHP () {
        if (monsterHP <= 0) {//���ó��
            GetComponent<Animator>().SetBool("Death", true);
            Destroy(gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().countMonsterDeath++;
            GameObject gold = Instantiate(GoldPrefab, transform.position, transform.rotation);
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
/*        if (collision.gameObject.tag == "attackCollider") {
            Hit();
        }*/
        if (collision.gameObject.tag == "Player" || 
            collision.gameObject.tag == "Turret" || 
            collision.gameObject.tag == "Barricade" ||
            collision.gameObject.tag == "Nexus") {
            Attack();
        }
    }
    private void OnCollisionExit2D (Collision2D collision) {
        if (collision.gameObject.tag == "Player" ||
        collision.gameObject.tag == "Turret" ||
        collision.gameObject.tag == "Barricade" ||
        collision.gameObject.tag == "Nexus")
        {
            GetComponent<Animator>().SetBool("Attack", false);
            transform.GetChild(0).gameObject.SetActive(false);
        }//��� �浹ü�� ���̸� Run���� ���ư���
        isEncounter = false;
    }
/*    void Hit () {
        isEncounter = true;
        GetComponent<Animator>().SetBool("Hit", true);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
            GetComponent<Animator>().SetBool("Hit", false);
            isEncounter = false;
        }
    }*/
    void Attack () {
        isEncounter = true;
        GetComponent<Animator>().SetBool("Attack", true);
        transform.GetChild(0).gameObject.SetActive(true);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
            GetComponent<Animator>().SetBool("Attack", false);
            transform.GetChild(0).gameObject.SetActive(false);
            isEncounter = false;
        }
    }
}
