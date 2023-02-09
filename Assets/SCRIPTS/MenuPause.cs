using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
   
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; 


    private void Start()
    {
        Time.timeScale = 1f;
        
    }

    public void  PauseGame()
    {
        
        if (GameIsPaused)
        {
            Play();
        }
        else
        {
            Stop();
        }

        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game1");
        Time.timeScale = 1f;
    }

    public  void Play()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Stop()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("RollballMEnu");   
       
        
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ArcadeRoom");

    }
    
    
    
    
    
}