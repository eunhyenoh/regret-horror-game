using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpKy2 : MonoBehaviour
{
    public GameObject keyOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public GameObject Text;
    public GameObject Text1;


    public AudioSource keySound;

    public bool inReach;


    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
        Text.SetActive(false);
        Text1.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);

        }
    }


    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            keyOB.SetActive(false);
            keySound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
            Text.SetActive(true);
            Text1.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
           // Destroy(gameObject);
        }


    }
}