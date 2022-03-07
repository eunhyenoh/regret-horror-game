using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SavePlayerData : MonoBehaviour
{
    [Header("세이브와 관련된 것들")]
    public DataController data; //세이브 파일 

    //이거 스크립트를 On,Off해야 이벤트나 인벤토리 확인 가능함 
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    private void Awake()
    {      
        data.LoadGameData();    //로드 해줘야 정보 불러옴
        if (IntroManager.mode == 0) data.gameData.isFirst = true;
        else data.gameData.isFirst = false;
        if (data.gameData.isFirst) gameObject.transform.position = new Vector3(-30, 1, 30);
        else gameObject.transform.position = data.gameData.position;
    }

    private void Start()
    {
        Invoke("Respwan", 1f);  // 바로 스크립트 ON해주면 저장된 position에 안가서 시간을 줌 
    }

    private void Respwan()
    {
        controller.enabled = true;
    }
}


/*
FirstPersonController 참조 방법?
 https://answers.unity.com/questions/988322/how-can-i-access-firstpersoncontroller-script-vari.html
마우스 커서
https://ncube-studio.tistory.com/entry/%EB%A7%88%EC%9A%B0%EC%8A%A4-%EC%BB%A4%EC%84%9C-%EC%9E%A0%EA%B7%B8%EA%B8%B0%EC%99%80-%ED%92%80%EA%B8%B0-%EC%88%A8%EA%B8%B0%EA%B8%B0%EC%99%80-%EB%B3%B4%EC%9D%B4%EA%B8%B0-How-to-Hide-and-Lock-the-Mouse-Cursor-%EC%9C%A0%EB%8B%88%ED%8B%B0-%EA%B2%8C%EC%9E%84-%EA%B0%9C%EB%B0%9C-%ED%8A%9C%ED%86%A0%EB%A6%AC%EC%96%BCUnity-C-Script
 

 */