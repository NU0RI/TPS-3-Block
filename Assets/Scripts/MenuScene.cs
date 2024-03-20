using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    public static bool GameIsPoused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPoused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
    }
        
    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPoused = false;
        GetComponent<BulletCaster>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPoused = true;
        GetComponent<BulletCaster>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
