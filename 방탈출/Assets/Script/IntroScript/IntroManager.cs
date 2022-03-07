using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // 0:ó�� ���� ���� 1:�̾��ϱ�? �̷��� �ϸ� �ɵ�? 
    public static int mode = 0;

    private DataController data;
    public GameObject intro;    
    public GameObject connectingText;   //Start������ ���� �������� ���� 
    public GameObject continue_Btn;
    // Start is called before the first frame update
    void Start()
    {
        data = gameObject.GetComponent<DataController>();
        data.LoadGameData();    //�����͸� �ε��ؿͼ� Continue��ư ���;����� �ȳ��;����� �˷��� 
        Cursor.visible = true;  
        Cursor.lockState = CursorLockMode.None;
        Screen.SetResolution(1920, 1080, true);  
        Debug.Log(data.gameData.isFirst);
        if (data.gameData.isFirst == false) continue_Btn.SetActive(true);
    }

    // ���� ���� 
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
    // ���� ����
    public void GameExitBtn()
    {
        Application.Quit();
    }
}
