using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteWorkOff : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject closenDoor;
    public GameObject outDoor;   //��۽ǿ��� ���̺� �߸��Ǽ� �����ϱ� �׳� false�� ���ֱ�.

    public bool isStage3 = false;
   

    private void OnDisable()    //������Ʈ�� off�Ǵ� ���� �ߵ� 
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


//�������� 3 ��ȣ�ǿ����� ���̴µ� ��ũ��Ʈ �ϳ� �� ����� �����Ƽ� �׳� ���� 
//������ ��Ʈ�Ͽ��� ���̴� ��ũ��Ʈ�Դϴ�. 
