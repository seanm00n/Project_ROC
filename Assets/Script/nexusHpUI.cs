using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nexusHpUI : MonoBehaviour
{
    public GameObject nexus;

    private void Start()
    {
        GetComponent<Image>().fillAmount = 1;
    }
    void Update()
    {
        GetComponent<Image>().fillAmount =
            nexus.GetComponent<Nexus>().nexusHP / 100;
    }
}
