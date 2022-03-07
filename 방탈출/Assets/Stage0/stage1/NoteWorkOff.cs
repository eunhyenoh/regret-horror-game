using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteWorkOff : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject closenDoor;
    public GameObject outDoor;   //방송실에서 세이브 잘못되서 갖히니까 그냥 false로 해주기.

    public bool isStage3 = false;
   

    private void OnDisable()    //오브젝트가 off되는 순간 발동 
    {
        closenDoor.SetActive(false);
        outDoor.SetActive(false);
        openDoor.SetActive(true);       
    }

    private void Update()
    {
        if(isStage3)
        {
            if(gameObject.GetComponent<OpenBoxWithLoopScript>().enabled==false)
            {
                closenDoor.SetActive(false);
                outDoor.SetActive(false);
                openDoor.SetActive(true);
            }
        }
    }
}


//스테이지 3 양호실에서도 쓰이는데 스크립트 하나 더 만들기 귀찮아서 그냥 썼어요 
//원래는 노트북에서 쓰이는 스크립트입니다. 
