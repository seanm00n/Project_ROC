using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int goldValue;
    GameObject gameController;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D (Collision2D collision) {
        gameController = GameObject.Find("GameController");
        if (collision.gameObject.tag == "Player") {
            gameController.GetComponent<GameController>().gold += goldValue;
            Destroy(gameObject);
        }
    }
}
