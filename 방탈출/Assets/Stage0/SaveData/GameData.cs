using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable] // ����ȭ


public class GameData 
{
    public bool isFirst = true; //true�� �����ǰ��� ���� ������ ������ 

    // �� é���� ��ݿ���
    public bool Stage0;
    public bool Stage1; 
    public bool Stage2; 
    public bool Stage3; 
    public bool Stage4;

    // �÷��̾� ��ġ �����̼� ���� 
    public Vector3 position;
        
    public GameObject[] text;   //���Ϸ��� �𸣰��� 
    
}
