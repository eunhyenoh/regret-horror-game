using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable] // 직렬화


public class GameData 
{
    public bool isFirst = true; //true면 포지션값이 정문 앞으로 고정됨 

    // 각 챕터의 잠금여부
    public bool Stage0;
    public bool Stage1; 
    public bool Stage2; 
    public bool Stage3; 
    public bool Stage4;

    // 플레이어 위치 로테이션 저장 
    public Vector3 position;
        
    public GameObject[] text;   //쓰일려나 모르것음 
    
}
