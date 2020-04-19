using UnityEngine;
using System.Collections;
using System;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused;
    public GameObject PauseMenuUI;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;        
    }
    public void LoadGame()
    {

    }
    public void QuitGame()
    {

    }

}
