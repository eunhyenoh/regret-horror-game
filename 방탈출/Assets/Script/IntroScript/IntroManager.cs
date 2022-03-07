using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // 0:처음 게임 시작 1:이어하기? 이렇게 하면 될듯? 
    public static int mode = 0;

    private DataController data;
    public GameObject intro;    
    public GameObject connectingText;   //Start누르면 게임 접속중이 나옴 
    public GameObject continue_Btn;
    // Start is called before the first frame update
    void Start()
    {
        data = gameObject.GetComponent<DataController>();
        data.LoadGameData();    //데이터를 로드해와서 Continue버튼 나와야할지 안나와야할지 알려줌 
        Cursor.visible = true;  
        Cursor.lockState = CursorLockMode.None;
        Screen.SetResolution(1920, 1080, true);  
        Debug.Log(data.gameData.isFirst);
        if (data.gameData.isFirst == false) continue_Btn.SetActive(true);
    }

    // 게임 시작 
    public void GameStartBtn()
    {
        mode = 0;
        intro.SetActive(false);
        connectingText.SetActive(true);
        SceneManager.LoadScene(1);  
    }
   
    public void Continue_Game()
    {
        mode = 1;
        intro.SetActive(false);
        connectingText.SetActive(true);
        SceneManager.LoadScene(1);
    }
    // 게임 종료
    public void GameExitBtn()
    {
        Application.Quit();
    }
}
