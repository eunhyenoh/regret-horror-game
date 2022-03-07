using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;    //�̱���

    public bool testing = false;

    public DataController data;
    public GameObject[] stage;

    private void Awake()
    {
        Instance = this;    //�̱���

        //������ ������ 
        data = GameObject.FindWithTag("Player").GetComponent<DataController>();

        //�ڱ� �ڽĵ� ��ŭ stage�迭�� �־��� 
        stage = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            stage[i] = gameObject.transform.GetChild(i).gameObject;
        }
        
        data.LoadGameData();    //������ �ε� �ڡ� �ſ��߿� �����Ϳ� �����Ϸ��� ��ũ��Ʈ���� LoadGameData ������� 
        CheckStage();   //�����ͺ��̽��� ����� ���� ���� Stage üũ
    }
    void Start()
    {
        // ���� ó�� ������ ��� stage�� ���� false��� stage1���� ���� (�Ϻη� Awake ���� Start�� ����)
        bool isStart = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (stage[i].activeSelf != true) continue;
            else isStart = true;
        }
        if (!isStart || data.gameData.isFirst)  //ù�����̰ų� StageŬ�����Ѱ� ���ٸ� 
        {
            StageStart(0);
        }
       // else if (testing)   StageStart(0); 
          
    }

    //�� �Լ��� ���൵�� Ȯ���� �� ���� 
    void CheckStage()
    {
        stageReset();   //�������� �ʱ�ȭ 
        if (data.gameData.Stage0)
        {
            stage[0].SetActive(true);
        }
        else if (data.gameData.Stage1)
        {
            stage[1].SetActive(true);
        }
        else if (data.gameData.Stage2)
        {
            stage[2].SetActive(true);
        }
        else if (data.gameData.Stage3)
        {
            stage[3].SetActive(true);
        }
        else if (data.gameData.Stage4)
        {
            stage[4].SetActive(true);
        }
    }

    public void StageStart(int stage_number)
    {
        stageReset();   //�������� �ʱ�ȭ
        reset_stage();  //�������� Bool�� �ʱ�ȭ 
        stage[stage_number].SetActive(true);
        switch (stage_number)
        {
            case 0:
                data.gameData.Stage0 = true;
                break;
            case 1:
                data.gameData.Stage1 = true;
                break;
            case 2:
                data.gameData.Stage2 = true;
                break;
            case 3:
                data.gameData.Stage3 = true;
                break;
            case 4:
                data.gameData.Stage4 = true;
                break;
        }
    }

    void stageReset()
    {
        for (int i = 0; i < stage.Length; i++)
        {
            stage[i].SetActive(false);
        }
    }

    // �����ͺ��̽� ���� �Լ� =====================================================================================
    //�����ͺ��̽��� bool�� false�� �ʱ�ȭ ���ش�.
    void reset_stage()
    {
        data.gameData.Stage0 = false;
        data.gameData.Stage1 = false;
        data.gameData.Stage2 = false;
        data.gameData.Stage3 = false;
        data.gameData.Stage4 = false;
    }

    // ���� ���� �� 
    private void OnApplicationQuit()
    {
        //data.gameData.Stage5Clear = true;
    }
    // ============================================================================================================
}


/*
 *  Ư�� ��Ҹ��� SavePoint�� ������ ���⿡ Trigger�� �ɸ��� Save �̰͵� Stage �ؿ� ����� �ּ� 
 Stage�� Ŭ���� �Ǹ� �װ��� �ٽ� ���̺� ������ ������ 
 
�������� Ŭ���� �ɶ����� bool�� �������ִ°� �������� ���� ��������3->4 �̷������� ���� true false���� ���ϱ� 


�ͽ����� ������ �׾��� ��츦 �����غ��� 

1.���� �������� �κ��丮�� ���Ź����� ����� �� ������ -> �ٽ� ����? 
2. �ƴϸ� ��� ���̺긦 ���� ���ټ� �ְ� ���ش�? -> ���Ź��鸸 �������ش�? 
-> �� ��� ������ �Ͼ�� ��ȣ�ۿ�� ó���� ��� ������ϴ��� ���� ��������
3. �ƴϸ� �����ڵ��� ������ �������� ���̺� ����Ʈ�� ������ش�?
-> ��������4�� ����� ��� Save 4.5 �̷������� �����༭?




�б����� �ؾ��� �� ����

���⼭ �ٽ� ���� ó�� Stage1�� ��� ������ �̱굵 �����ε� 

StageManager�ȿ� �ִ� Stage1 SavePoint�� ����ϸ� stage1=true�� �ǰ� Stage1_ComputerRoom�� Ȱ��ȭ �Ǿ���� 
���� ����ġ�� �� ã���� �� opendoor�� Ȱ��ȭ �Ǹ鼭 Stage1�� clear �ǰ� ������ Stage2�� bool���� true�� �ǰ�
stage1�� false�� ��ȯ�� �̰� ���� �ۿ��ٰ� SavePoint�� �� ������ �ҵ�?

 StageStart(int i) �Լ��� �̿� ������ Stage(2) �̱������� �޾Ƽ� 2�����Ѵٴ°� �˷��ֱ�?
 */