using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndingTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoMainScene", 60f);
    }

    void GoMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
