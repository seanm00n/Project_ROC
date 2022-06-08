using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charHpUI : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        GetComponent<Image>().fillAmount = 1;
    }
    void Update()
    {
        GetComponent<Image>().fillAmount = 
            player.GetComponent<Player>().charHP / 100;
    }
}
