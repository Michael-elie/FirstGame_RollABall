using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public TextMeshProUGUI HStext;


    private void Start()
    {
        HStext.text = "" + PlayerPrefs.GetInt("highscore");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game1");

    }

    public void QuitGame()
    {
        SceneManager.LoadScene("ArcadeRoom");

    }
    
 
        
    
   
}
