using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public void OnClickStartButton () {
        SceneManager.LoadScene(1);
    }
    public void OnClickExitButton () {
        Application.Quit();
    }
    public void getNextStageButtonDown()
    {
        SceneManager.LoadScene(1);
    }
    public void getMainButtonDown()
    {
        SceneManager.LoadScene(0);
    }
    public void getExitButtonDown()
    {
        Application.Quit();
    }
}
