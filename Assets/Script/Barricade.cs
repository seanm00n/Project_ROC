using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    public float barricadeHP = 10f;

    void Update()
    {
        checkHP();
    }
    void checkHP () {
        if (barricadeHP <= 0) {//���ó��
            Destroy(gameObject);
        }
    }
}
