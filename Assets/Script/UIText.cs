using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIText : MonoBehaviour
{
    public Text goldText;
    //public Text charText;
    //public Text nexusText;
    public GameController gameController;
    //public Player player;
    //public Nexus nexus;
    void Update()
    {
        goldText.text = "Gold : " + gameController.GetComponent<GameController>().gold;
        //charText.text = ""+ player.GetComponent<Player>().charHP;
        //nexusText.text = ""+ nexus.GetComponent<Nexus>().nexusHP;
    }
    
}
