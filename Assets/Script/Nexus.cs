using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    public float nexusHP;
    void Update()
    {
        
    }
    void checkHP () {
        if(nexusHP < 0) {
            Destroy(gameObject);
        }
    }
}
