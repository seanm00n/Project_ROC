using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int goldValue;
    public GameObject gameManager;//�ٸ� ������� �����;���
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            gameManager.GetComponent<GameController>().gold += goldValue;
            Destroy(gameObject);
        }
    }
}
