using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageFadeInSystem : MonoBehaviour
{
    //public static ImageFadeInSystem Instance;

    public GameObject nextImage;

    public bool ending = false;

    private Image image;

    float fadeCount = 0.3f;

    private void Awake()
    {
        //Instance = this;
        image = gameObject.GetComponent<Image>();   //자기꺼 이미지 갖고옴
    }
    private void Start()
    {
        //StartCoroutine(FadeCoroutine(image));
    }

    //활성화 될때마다 다시 코루틴 반복
    private void OnEnable()
    {
        fadeCount = 0.3f;
        StartCoroutine(FadeCoroutine(image));
        Invoke("NextImageOn", 5f);
    }

    public IEnumerator FadeCoroutine(Image image)
    {
        if(ending)
        {
            while (fadeCount < 1.0f)
            {
                fadeCount += 0.005f;
                yield return new WaitForSeconds(0.01f); //0.01초마다 실행 
                image.color = new Color(0, 0, 0, fadeCount);
            }
        }
        else
        {
            while (fadeCount < 1.0f)
            {
                fadeCount += 0.005f;
                yield return new WaitForSeconds(0.01f); //0.01초마다 실행 
                image.color = new Color(255, 255, 255, fadeCount);
            }
        }
        
    }

    void NextImageOn()
    {
        nextImage.SetActive(true);
        gameObject.SetActive(false);
    }
}

//해당 씬은 인트로에만 쓰여용 