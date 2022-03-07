using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;    //싱글톤

    public bool testing = false;

    public DataController data;
    public GameObject[] stage;

    private void Awake()
    {
        Instance = this;    //싱글톤

        //데이터 가져옴 
        data = GameObject.FindWithTag("Player").GetComponent<DataController>();

        //자기 자식들 만큼 stage배열에 넣어줌 
        stage = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            stage[i] = gameObject.transform.GetChild(i).gameObject;
        }
        
        data.LoadGameData();    //데이터 로드 ★★ 매우중요 데이터에 접근하려면 스크립트마다 LoadGameData 해줘야함 
        CheckStage();   //데이터베이스에 저장된 값에 따라 Stage 체크
    }
    void Start()
    {
        // 만일 처음 시작일 경우 stage가 전부 false경우 stage1부터 시작 (일부러 Awake 이후 Start에 넣음)
        bool isStart = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (stage[i].activeSelf != true) continue;
            else isStart = true;
        }
        if (!isStart || data.gameData.isFirst)  //첫시작이거나 Stage클리어한게 없다면 
        {
            StageStart(0);
        }
       // else if (testing)   StageStart(0); 
          
    }

    //이 함수로 진행도를 확인할 수 있음 
    void CheckStage()
    {
        stageReset();   //스테이지 초기화 
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
        stageReset();   //스테이지 초기화
        reset_stage();  //스테이지 Bool값 초기화 
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

    // 데이터베이스 관련 함수 =====================================================================================
    //데이터베이스에 bool값 false로 초기화 해준다.
    void reset_stage()
    {
        data.gameData.Stage0 = false;
        data.gameData.Stage1 = false;
        data.gameData.Stage2 = false;
        data.gameData.Stage3 = false;
        data.gameData.Stage4 = false;
    }

    // 게임 종료 시 
    private void OnApplicationQuit()
    {
        //data.gameData.Stage5Clear = true;
    }
    // ============================================================================================================
}


/*
 *  특정 장소마다 SavePoint를 만들어둠 여기에 Trigger가 걸리면 Save 이것도 Stage 밑에 상속해 둬서 
 Stage가 클리어 되면 그곳엔 다시 세이브 될일이 없게함 
 
스테이지 클리어 될때마다 bool갑 변경해주는것 잊지말것 또한 스테이지3->4 이런식으로 갈시 true false관리 잘하기 


귀신한테 잡혀서 죽었을 경우를 생각해보자 

1.만일 스테이지 인벤토리에 증거물들을 모았을 때 죽으면 -> 다시 시작? 
2. 아니면 계속 세이브를 직접 해줄수 있게 해준다? -> 증거물들만 관리해준다? 
-> 이 경우 그전에 일어났던 상호작용들 처리를 어떻게 해줘야하는지 조금 어지러움
3. 아니면 제작자들이 임의의 지점마다 세이브 포인트를 만들어준다?
-> 스테이지4가 어려운 경우 Save 4.5 이런식으로 갈라줘서?




학교에서 해야할 것 정리

여기서 다시 문제 처음 Stage1을 어떻게 켜줄지 이깃도 문제인듯 

StageManager안에 있는 Stage1 SavePoint를 통과하면 stage1=true가 되고 Stage1_ComputerRoom이 활성화 되어야함 
또한 스위치를 다 찾았을 시 opendoor가 활성화 되면서 Stage1이 clear 되고 이제는 Stage2의 bool값이 true가 되고
stage1은 false로 변환됨 이거 또한 밖에다가 SavePoint를 더 만들어야 할듯?

 StageStart(int i) 함수를 이용 끝나면 Stage(2) 싱글톤으로 받아서 2시작한다는걸 알려주긔?
 */