using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public TextMeshProUGUI HStext;
    public TextMeshPro HStextposter;
    public TextMeshProUGUI Scoretext;
    public PLAYER playerscript;


    private void Start()
    {
        HStext.text = "" + PlayerPrefs.GetInt("highscore");
        HStextposter.text =  PlayerPrefs.GetInt("highscore") + " POINTS";
        Scoretext.text = "" + playerscript.Score;
        //Cursor.lockState = CursorLockMode.Locked; 
        //Cursor.visible = false;
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
