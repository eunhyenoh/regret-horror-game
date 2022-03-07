using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SavePlayerData : MonoBehaviour
{
    [Header("���̺�� ���õ� �͵�")]
    public DataController data; //���̺� ���� 

    //�̰� ��ũ��Ʈ�� On,Off�ؾ� �̺�Ʈ�� �κ��丮 Ȯ�� ������ 
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    private void Awake()
    {      
        data.LoadGameData();    //�ε� ����� ���� �ҷ���
        if (IntroManager.mode == 0) data.gameData.isFirst = true;
        else data.gameData.isFirst = false;
        if (data.gameData.isFirst) gameObject.transform.position = new Vector3(-30, 1, 30);
        else gameObject.transform.position = data.gameData.position;
    }

    private void Start()
    {
        Invoke("Respwan", 1f);  // �ٷ� ��ũ��Ʈ ON���ָ� ����� position�� �Ȱ��� �ð��� �� 
    }

    private void Respwan()
    {
        controller.enabled = true;
    }
}


/*
FirstPersonController ���� ���?
 https://answers.unity.com/questions/988322/how-can-i-access-firstpersoncontroller-script-vari.html
���콺 Ŀ��
https://ncube-studio.tistory.com/entry/%EB%A7%88%EC%9A%B0%EC%8A%A4-%EC%BB%A4%EC%84%9C-%EC%9E%A0%EA%B7%B8%EA%B8%B0%EC%99%80-%ED%92%80%EA%B8%B0-%EC%88%A8%EA%B8%B0%EA%B8%B0%EC%99%80-%EB%B3%B4%EC%9D%B4%EA%B8%B0-How-to-Hide-and-Lock-the-Mouse-Cursor-%EC%9C%A0%EB%8B%88%ED%8B%B0-%EA%B2%8C%EC%9E%84-%EA%B0%9C%EB%B0%9C-%ED%8A%9C%ED%86%A0%EB%A6%AC%EC%96%BCUnity-C-Script
 

 */