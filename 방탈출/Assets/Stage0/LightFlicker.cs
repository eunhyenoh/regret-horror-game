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
    public static int result = 5; // ����ġ �� �������� 0���� ���ϸ鼭 Ŭ���� 

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
            // �������� Ŭ����
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