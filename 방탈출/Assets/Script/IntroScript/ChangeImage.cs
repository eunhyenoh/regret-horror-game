using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    GameObject[] objects;

    int order = 0;  //������� �̹��� �ݺ���Ű���� ������ ���� 

    // Start is called before the first frame update
    private void Awake()
    {
        objects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            objects[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeImages()
    {
        yield return new WaitForSeconds(3f);
    }
}
