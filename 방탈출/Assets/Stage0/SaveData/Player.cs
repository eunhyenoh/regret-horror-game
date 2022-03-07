using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("세이브와 관련된 것들")]
    public DataController data; //세이브 파일
    public GameObject[] text;   // 세이브 텍스트? (실험) 추후에 삭제 가능 
    public GameObject texts;    // 세이브 텍스트 부모객체     

    //이거 스크립트를 On,Off해야 이벤트나 인벤토리 확인 가능함 
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    private void Awake()
    {
        data.LoadGameData();    //로드 해줘야 정보 불러옴 
        gameObject.transform.position = data.gameData.position;

        
        if (data.gameData.text.Length != 0)
        {
            //0이 아니란건 세이브 데이터가 있다는 거니 불러오기
            //Debug.Log("0이네");
            // 배열을 재 선언해서 세이브된 데이터 규격에 맞춰서 불러와주기 이런식으로 가면 될듯?
            text = new GameObject[data.gameData.text.Length];
            for(int i=0;i<data.gameData.text.Length;i++)
            {
                text[i] = data.gameData.text[i];
            }
        }
        // 만일 세이브 데이터가 없다면 자식개체들 가져와서 배열안에 넣어준다. 
        else
        {
            text = new GameObject[texts.transform.childCount];
            for(int i=0;i<transform.childCount;i++)
            {
                //Debug.Log("이게 실행됨");
                text[i] = texts.transform.GetChild(i).gameObject;
            }
        }
        
    }

    private void Start()
    {
        Invoke("Respwan", 1f);  // 바로 스크립트 ON해주면 저장된 position에 안가서 시간을 줌 
    }


    private void Update()
    {
        // 잘 조정해서 인벤토리 할 때 적용시켜주면 될듯함?
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


   
    /* 추후에 다시 만져보자 (세이브 데이터 함수)
    public void isHaveSaveData(GameObject[] saveData, GameObject parentsObject)
    {      
        if (data.gameData.text.Length != 0)
        {
            //0이 아니란건 세이브 데이터가 있다는 거니 불러오기
            Debug.Log("세이브 있네");
            // 배열을 재 선언해서 세이브된 데이터 규격에 맞춰서 불러와주기 이런식으로 가면 될듯?
            saveData = new GameObject[data.gameData.text.Length];
            for (int i = 0; i < data.gameData.text.Length; i++)
            {
                saveData[i] = data.gameData.text[i];
            }
        }
        // 만일 세이브 데이터가 없다면 자식개체들 가져와서 배열안에 넣어준다. 
        else
        {
            saveData = new GameObject[parentsObject.transform.childCount];
            for (int i = 0; i < parentsObject.transform.childCount; i++)
            {
                Debug.Log("이게 실행됨");
                saveData[i] = parentsObject.transform.GetChild(i).gameObject;
                Debug.Log(saveData[i]);
            }
        }
    }*/
    

    //만일 게임이 종료된다면 
    private void OnApplicationQuit()
    {
        data.gameData.position = gameObject.transform.position; //마지막에 있던 포지션 저장 
        data.gameData.text = new GameObject[text.Length];   //★★배열 초기화 이렇게 해야 저장될때도 오브젝트에 맞춰서 저장됨
        for(int i=0;i<text.Length;i++)
        {
            data.gameData.text[i] = text[i];
        }
    }
}


/*
FirstPersonController 참조 방법?
 https://answers.unity.com/questions/988322/how-can-i-access-firstpersoncontroller-script-vari.html
마우스 커서
https://ncube-studio.tistory.com/entry/%EB%A7%88%EC%9A%B0%EC%8A%A4-%EC%BB%A4%EC%84%9C-%EC%9E%A0%EA%B7%B8%EA%B8%B0%EC%99%80-%ED%92%80%EA%B8%B0-%EC%88%A8%EA%B8%B0%EA%B8%B0%EC%99%80-%EB%B3%B4%EC%9D%B4%EA%B8%B0-How-to-Hide-and-Lock-the-Mouse-Cursor-%EC%9C%A0%EB%8B%88%ED%8B%B0-%EA%B2%8C%EC%9E%84-%EA%B0%9C%EB%B0%9C-%ED%8A%9C%ED%86%A0%EB%A6%AC%EC%96%BCUnity-C-Script
 

 */