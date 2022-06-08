using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D charRigid;//���� rigid
    public GameObject turretPrefab01;//��ž
    public GameObject turretPrefab02;//��ž
    public GameObject turretPrefab03;//��ž
    public GameObject turretPrefab04;//��ž
    public GameObject barricatePrefab01;//��
    public GameObject barricatePrefab02;//��
    public GameObject barricatePrefab03;//��
    public GameObject barricatePrefab04;//��
    public GameObject colliderPrefab;
    public GameObject bulletPrefab;
    GameObject colliderObject;
    public Animator animator;
    public GameController gameController;
    public float charSpeed = 5f;
    public float charAP = 4f;
    public float charHP = 20f;
    public float charFixP = 2f;
    
    private float coolTime01 = 0f;
    private float coolTime02 = 0f;
    private float coolTime03 = 0f;
    private Vector3 pos;

    void Update()
    {
        Move();
        buildTurret();
        buildBarricade();
        Attack();
        AttackEnd();
    }

    void Move()
    {
        float input = Input.GetAxisRaw("Horizontal");
        Vector3 vel = new Vector3(0, charRigid.velocity.y, 0);

        if (input != 0)//�Է� ���� ��
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
        coolTime01 += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (coolTime01 < 1f) {
                Debug.Log("CoolTime");
                return;
            }
            if (gameController.GetComponent<GameController>().gold < 5) {
                Debug.Log("Not Enough Gold");
                return;
            }
            coolTime01 = 0f;
            pos = transform.position;
            pos = new Vector3(transform.position.x, -3.6f, transform.position.z);
            GameObject turret = Instantiate(turretPrefab01, pos, transform.rotation);
            gameController.GetComponent<GameController>().gold -= 5;
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            if (coolTime01 < 1f) {
                Debug.Log("CoolTime");
                return;
            }
            if (gameController.GetComponent<GameController>().gold < 10) {
                Debug.Log("Not Enough Gold");
                return;
            }
            coolTime01 = 0f;
            pos = transform.position;
            pos = new Vector3(transform.position.x, -3.6f, transform.position.z);
            GameObject turret = Instantiate(turretPrefab02, pos, transform.rotation);
            gameController.GetComponent<GameController>().gold -= 10;
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            if (coolTime01 < 1f) {
                Debug.Log("CoolTime");
                return;
            }
            if (gameController.GetComponent<GameController>().gold < 15) {
                Debug.Log("Not Enough Gold");
                return;
            }
            coolTime01 = 0f;
            pos = transform.position;
            pos = new Vector3(transform.position.x, -3.6f, transform.position.z);
            GameObject turret = Instantiate(turretPrefab03, pos, transform.rotation);
            gameController.GetComponent<GameController>().gold -= 15;
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            if (coolTime01 < 1f) {
                Debug.Log("CoolTime");
                return;
            }
            if (gameController.GetComponent<GameController>().gold < 20) {
                Debug.Log("Not Enough Gold");
                return;
            }
            coolTime01 = 0f;
            pos = transform.position;
            pos = new Vector3(transform.position.x, -3.6f, transform.position.z);
            GameObject turret = Instantiate(turretPrefab04, pos, transform.rotation);
            gameController.GetComponent<GameController>().gold -= 20;
        }
    }
    void buildBarricade () {
        coolTime02 += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A)) {
            if (coolTime02 < 1f) {
                Debug.Log("CoolTime");
                return;
            }
            if (gameController.GetComponent<GameController>().gold < 5) {//���̺����ϸ�
                Debug.Log("Not Enough Gold");
                return;
            }
            gameController.GetComponent<GameController>().gold -= 5;
            coolTime02 = 0f;
            pos = new Vector3(transform.position.x, -3.54f, transform.position.z);
            GameObject barricade = Instantiate(barricatePrefab01, pos, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            if (coolTime02 < 1f) {
                Debug.Log("CoolTime");
                return;
            }
            if (gameController.GetComponent<GameController>().gold < 10) {//���̺����ϸ�
                Debug.Log("Not Enough Gold");
                return;
            }
            gameController.GetComponent<GameController>().gold -= 10;
            coolTime02 = 0f;
            pos = new Vector3(transform.position.x, -3.54f, transform.position.z);
            GameObject barricade = Instantiate(barricatePrefab02, pos, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            if (coolTime02 < 1f) {
                Debug.Log("CoolTime");
                return;
            }
            if (gameController.GetComponent<GameController>().gold < 15) {//���̺����ϸ�
                Debug.Log("Not Enough Gold");
                return;
            }
            gameController.GetComponent<GameController>().gold -= 15;
            coolTime02 = 0f;
            pos = new Vector3(transform.position.x, -3.72f, transform.position.z);
            GameObject barricade = Instantiate(barricatePrefab03, pos, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            if (coolTime02 < 1f) {
                Debug.Log("CoolTime");
                return;
            }
            if (gameController.GetComponent<GameController>().gold < 20) {//���̺����ϸ�
                Debug.Log("Not Enough Gold");
                return;
            }
            gameController.GetComponent<GameController>().gold -= 20;
            coolTime02 = 0f;
            pos = new Vector3(transform.position.x, -3.72f, transform.position.z);
            GameObject barricade = Instantiate(barricatePrefab04, pos, transform.rotation);
        }
    }
    void Attack () {
        coolTime03 += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z)) {
            if (coolTime03 < 1f) {
                return;
            }
            coolTime03 = 0f;
            GetComponent<Animator>().SetBool("Attack",true);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //colliderObject = Instantiate(colliderPrefab, transform.position, transform.rotation);
            //colliderObject.transform.parent = this.transform;
        }     
    }
    void AttackEnd () {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
            GetComponent<Animator>().SetBool("Attack", false);
            Destroy(colliderObject);
        }
    }
    void Throw () {

    }
}
