using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    float timer;
    int waitingTime;
    public GameObject src;
    void Start()
    {
        timer = 0.0f;
        waitingTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            timer = 0;
            GameObject instance = Instantiate(src, transform.position, transform.rotation);
            Destroy(instance, 2);
            //2초마다 생성, 2초 뒤 삭제
        }
        
    }
}
