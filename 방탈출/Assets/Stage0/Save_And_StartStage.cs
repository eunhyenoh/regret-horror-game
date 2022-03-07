using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_And_StartStage : MonoBehaviour
{
    public int whatStage = 0;
    public GameObject start_Trigger;
    public DataController data;

    public bool savePoint = false;
    public bool potionSavePoint = false;

    public void Awake()
    {
        data = GameObject.FindWithTag("Player").GetComponent<DataController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="Player")
        {
            //savePoint: 방문이 닫혀 탈출못하거나 그러한 곳에 놓는 것 진행할 스테이지를 넣어야함 
            if(savePoint)
            {
                StageManager.Instance.StageStart(whatStage);
                start_Trigger.SetActive(true);
                data.gameData.isFirst = false;
                data.SaveGameData();
                Destroy(gameObject);
            }
            //위치값만 저장하고 싶을때 what 스테이지는 진행중인 스테이지를 넣어야함 
            else if(potionSavePoint)
            {
                StageManager.Instance.StageStart(whatStage);
                data.SaveGameData();
                Destroy(gameObject);
            }       
        }
    }
}
