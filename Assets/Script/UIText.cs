using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIText : MonoBehaviour
{
    public Text goldText;
    public GameController gameController;
    void Update()
    {
        goldText.text = "Gold : " + gameController.GetComponent<GameController>().gold;
    }
    
}
