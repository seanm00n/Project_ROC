using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    private Transform self;
    void Start()
    {
        self = GetComponent<Transform>();
    }

 
    void Update()
    {
        self.position = new Vector3(target.position.x, 0,-10);
        //ī�޶� ��ġ�� ĳ���� ������
    }
}
