using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int gold;//재화
    public GameObject mPrefab;
    public GameObject player;
    public GameObject Nexus;
    public Text gaovText;
    public Text clearText;
    public Text timeText;
    public Text monsterNumText;
    public GameObject nextButton;
    public GameObject exitButton;
    public GameObject mainButton;

    public int MaxMonsterNum;
    public int countMonsterDeath = 0; //do not touch this value in inspector
    float ctime = 0f;
    float time = 0f;

    private void Start () {
        countMonsterDeath = 0;
        gaovText.gameObject.SetActive(false);
        clearText.gameObject.SetActive(false);
        exitButton.SetActive(false);
        mainButton.SetActive(false);
        nextButton.SetActive(false);
    }
    void Update()
    {
        checkClear();
        checkGAOV();
        if (countMonsterDeath < MaxMonsterNum) {
            genMob();
        }
        monsterNumText.text = "" + (MaxMonsterNum-countMonsterDeath);
        time += Time.deltaTime;
        timeText.text = ""+(int)time;
    }
    void genMob () {
        ctime += Time.deltaTime;
        if (ctime > 3f) {//1초 쿨로 몬스터 소환
            ctime = 0;
            GameObject mob = Instantiate(mPrefab, transform.position, transform.rotation);
        }
    }
    void checkClear () {
        if(countMonsterDeath == MaxMonsterNum) {
            //게임 멈추고 UI나옴(Clear텍스트, 다음 스테이지, 종료, 메인)
            clearText.gameObject.SetActive(true);
            exitButton.SetActive(true);
            mainButton.SetActive(true);
            nextButton.SetActive(true);
            Time.timeScale = 0;//정지
        }
    }
    void checkGAOV () {
        float playerHp = player.GetComponent<Player>().charHP;
        float nexusHp = Nexus.GetComponent<Nexus>().nexusHP;
        if (playerHp < 0 || nexusHp < 0) {//캐릭터 또는 넥서스 체력이 0이 되면
            //게임 멈추고 UI나옴(GAOV텍스트, 종료, 메인)
            gaovText.gameObject.SetActive(true);
            exitButton.SetActive(true);
            mainButton.SetActive(true);
            Time.timeScale = 0;//정지
        }
    }
}
