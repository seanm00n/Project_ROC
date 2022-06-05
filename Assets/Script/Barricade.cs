using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    public float baricadeHP = 10f;

    void Update()
    {
        checkHP();
    }
    void checkHP () {
        if (baricadeHP <= 0) {//»ç¸ÁÃ³¸®
            Destroy(gameObject);
        }
    }
}
