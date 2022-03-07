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
            //savePoint: �湮�� ���� Ż����ϰų� �׷��� ���� ���� �� ������ ���������� �־���� 
            if(savePoint)
            {
                StageManager.Instance.StageStart(whatStage);
                start_Trigger.SetActive(true);
                data.gameData.isFirst = false;
                data.SaveGameData();
                Destroy(gameObject);
            }
            //��ġ���� �����ϰ� ������ what ���������� �������� ���������� �־���� 
            else if(potionSavePoint)
            {
                StageManager.Instance.StageStart(whatStage);
                data.SaveGameData();
                Destroy(gameObject);
            }       
        }
    }
}
