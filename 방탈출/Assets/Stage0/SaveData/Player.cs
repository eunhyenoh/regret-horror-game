using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("���̺�� ���õ� �͵�")]
    public DataController data; //���̺� ����
    public GameObject[] text;   // ���̺� �ؽ�Ʈ? (����) ���Ŀ� ���� ���� 
    public GameObject texts;    // ���̺� �ؽ�Ʈ �θ�ü     

    //�̰� ��ũ��Ʈ�� On,Off�ؾ� �̺�Ʈ�� �κ��丮 Ȯ�� ������ 
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    private void Awake()
    {
        data.LoadGameData();    //�ε� ����� ���� �ҷ��� 
        gameObject.transform.position = data.gameData.position;

        
        if (data.gameData.text.Length != 0)
        {
            //0�� �ƴ϶��� ���̺� �����Ͱ� �ִٴ� �Ŵ� �ҷ�����
            //Debug.Log("0�̳�");
            // �迭�� �� �����ؼ� ���̺�� ������ �԰ݿ� ���缭 �ҷ����ֱ� �̷������� ���� �ɵ�?
            text = new GameObject[data.gameData.text.Length];
            for(int i=0;i<data.gameData.text.Length;i++)
            {
                text[i] = data.gameData.text[i];
            }
        }
        // ���� ���̺� �����Ͱ� ���ٸ� �ڽİ�ü�� �����ͼ� �迭�ȿ� �־��ش�. 
        else
        {
            text = new GameObject[texts.transform.childCount];
            for(int i=0;i<transform.childCount;i++)
            {
                //Debug.Log("�̰� �����");
                text[i] = texts.transform.GetChild(i).gameObject;
            }
        }
        
    }

    private void Start()
    {
        Invoke("Respwan", 1f);  // �ٷ� ��ũ��Ʈ ON���ָ� ����� position�� �Ȱ��� �ð��� �� 
    }


    private void Update()
    {
        // �� �����ؼ� �κ��丮 �� �� ��������ָ� �ɵ���?
        if (Input.GetKeyDown(KeyCode.F9))
        {
            controller.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            controller.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.F11))
        {
            controller.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void Respwan()
    {
        controller.enabled = true;
    }


   
    /* ���Ŀ� �ٽ� �������� (���̺� ������ �Լ�)
    public void isHaveSaveData(GameObject[] saveData, GameObject parentsObject)
    {      
        if (data.gameData.text.Length != 0)
        {
            //0�� �ƴ϶��� ���̺� �����Ͱ� �ִٴ� �Ŵ� �ҷ�����
            Debug.Log("���̺� �ֳ�");
            // �迭�� �� �����ؼ� ���̺�� ������ �԰ݿ� ���缭 �ҷ����ֱ� �̷������� ���� �ɵ�?
            saveData = new GameObject[data.gameData.text.Length];
            for (int i = 0; i < data.gameData.text.Length; i++)
            {
                saveData[i] = data.gameData.text[i];
            }
        }
        // ���� ���̺� �����Ͱ� ���ٸ� �ڽİ�ü�� �����ͼ� �迭�ȿ� �־��ش�. 
        else
        {
            saveData = new GameObject[parentsObject.transform.childCount];
            for (int i = 0; i < parentsObject.transform.childCount; i++)
            {
                Debug.Log("�̰� �����");
                saveData[i] = parentsObject.transform.GetChild(i).gameObject;
                Debug.Log(saveData[i]);
            }
        }
    }*/
    

    //���� ������ ����ȴٸ� 
    private void OnApplicationQuit()
    {
        data.gameData.position = gameObject.transform.position; //�������� �ִ� ������ ���� 
        data.gameData.text = new GameObject[text.Length];   //�ڡڹ迭 �ʱ�ȭ �̷��� �ؾ� ����ɶ��� ������Ʈ�� ���缭 �����
        for(int i=0;i<text.Length;i++)
        {
            data.gameData.text[i] = text[i];
        }
    }
}


/*
FirstPersonController ���� ���?
 https://answers.unity.com/questions/988322/how-can-i-access-firstpersoncontroller-script-vari.html
���콺 Ŀ��
https://ncube-studio.tistory.com/entry/%EB%A7%88%EC%9A%B0%EC%8A%A4-%EC%BB%A4%EC%84%9C-%EC%9E%A0%EA%B7%B8%EA%B8%B0%EC%99%80-%ED%92%80%EA%B8%B0-%EC%88%A8%EA%B8%B0%EA%B8%B0%EC%99%80-%EB%B3%B4%EC%9D%B4%EA%B8%B0-How-to-Hide-and-Lock-the-Mouse-Cursor-%EC%9C%A0%EB%8B%88%ED%8B%B0-%EA%B2%8C%EC%9E%84-%EA%B0%9C%EB%B0%9C-%ED%8A%9C%ED%86%A0%EB%A6%AC%EC%96%BCUnity-C-Script
 

 */