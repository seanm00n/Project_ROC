using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gold;//��ȭ
    public GameObject mPrefab;
    float ctime = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        ctime += Time.deltaTime;
        if(ctime > 3f) {//1�� ��� ���� ��ȯ
            ctime = 0;
            GameObject mob = Instantiate(mPrefab,transform.position, transform.rotation);
        }
    }
}
