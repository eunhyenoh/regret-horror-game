using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    GameObject[] objects;

    int order = 0;  //숫서대로 이미지 반복시키려고 선언한 변수 

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
