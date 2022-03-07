using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage4_Ending : MonoBehaviour
{
    // ���� �� ���ϴ°� 
    public GameObject closen_frontDoor;

    public GameObject fadeIn;

    public GameObject stage4;

    public DataController data;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    private void OnEnable()
    {
        closen_frontDoor.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            fadeIn.SetActive(true);
            controller.enabled = false;
            Invoke("MoveToEndingScene", 5f);
        }
    }

    void MoveToEndingScene()
    {
        data = GameObject.FindWithTag("Player").GetComponent<DataController>();
        data.gameData.isFirst = true;
        stage4.SetActive(false);    // �������°� �����ϱ� ���ؼ� 
        data.SaveGameData(); ;
        closen_frontDoor.SetActive(true);       
        SceneManager.LoadScene(2);
    }
}
