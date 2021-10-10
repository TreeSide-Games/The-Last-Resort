using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameOptions : MonoBehaviour
{
    public GameObject options;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            options.SetActive(true);
        }
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
