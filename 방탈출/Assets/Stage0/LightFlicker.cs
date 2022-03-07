using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightFlicker : MonoBehaviour
{

    public Light lightOB;

    public AudioSource lightSound;

    public float minTime;
    public float maxTime;
    public float timer;

    public Text text;
    public static int result = 5; // 스위치 다 내려가면 0으로 변하면서 클리어 

    public GameObject openDoor;
    public GameObject closeDoor;

    void Start()
    {
        timer = Random.Range(minTime, maxTime);

    }

    void Update()
    {
        LightsFlickering();

        text.text = result.ToString();
        if (result == 0)
        {
            Destroy(this);
        }
        if (result == 0)
        {
            // 스테이지 클리어
            closeDoor.SetActive(false);
            openDoor.SetActive(true);
        }
    }

    void LightsFlickering()
    {
        if (timer > 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            lightOB.enabled = !lightOB.enabled;
            timer = Random.Range(minTime, maxTime);
            lightSound.Play();
        }
    }
}