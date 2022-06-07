using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int gold;//��ȭ
    public GameObject mPrefab;
    public GameObject player;
    public GameObject Nexus;
    public Text gaovText;
    public Text clearText;
    public GameObject nextButton;
    public GameObject exitButton;
    public GameObject mainButton;

    public int MaxMonsterNum;
    int countMonster = 0;
    int countMonsterDeath = 0;
    float ctime = 0f;
    private void Start () {
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
        if (countMonster < MaxMonsterNum) {
            genMob();
        }
    }
    void genMob () {
        ctime += Time.deltaTime;
        if (ctime > 3f) {//1�� ��� ���� ��ȯ
            ctime = 0;
            GameObject mob = Instantiate(mPrefab, transform.position, transform.rotation);
            countMonster++;
        }
    }
    void checkClear () {
        if(countMonsterDeath == MaxMonsterNum) {
            //���� ���߰� UI����(Clear�ؽ�Ʈ, ���� ��������, ����, ����)
            clearText.gameObject.SetActive(true);
            exitButton.SetActive(true);
            mainButton.SetActive(true);
            nextButton.SetActive(true);
            Time.timeScale = 0;//����
        }
    }
    void checkGAOV () {
        float playerHp = player.GetComponent<Player>().charHP;
        float nexusHp = Nexus.GetComponent<Nexus>().nexusHP;
        if (playerHp < 0 || nexusHp < 0) {//ĳ���� �Ǵ� �ؼ��� ü���� 0�� �Ǹ�
            //���� ���߰� UI����(GAOV�ؽ�Ʈ, ����, ����)
            gaovText.gameObject.SetActive(true);
            exitButton.SetActive(true);
            mainButton.SetActive(true);
            Time.timeScale = 0;//����
        }
    }
}
