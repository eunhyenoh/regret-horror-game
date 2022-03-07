using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOFF : MonoBehaviour
{
    public GameObject light;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;
    // Start is called before the first frame update
    void Start()
    {
        off = true;
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (off && Input.GetButtonDown("F"))
        {
            light.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;
        }
        else if (on && Input.GetButtonDown("F"))
        {
            light.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }
    }
}
