using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OffMouse : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    // Start is called before the first frame update
    private void Update()
    {
        controller.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
