using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManaegr : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    public GameObject player_EscCanvas;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player_EscCanvas.SetActive(true);
            controller.enabled = false;
        }
    }
    public void OffBtn(GameObject button)
    {
        button.SetActive(false);
        controller.enabled = true;
    }
    public void Go_Main()
    {
        controller.enabled = false;
        player_EscCanvas.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void Continue_Game()
    {
        controller.enabled = true;
        player_EscCanvas.SetActive(false);
    }
    public void Exit_Game()
    {
        controller.enabled = false;
        player_EscCanvas.SetActive(false);
        Application.Quit();
    }
}
