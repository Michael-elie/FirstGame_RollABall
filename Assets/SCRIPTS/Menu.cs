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
   // public PLAYER playerscript;
    [SerializeField] private AppData Choice;

    private void Start()
    {
        HStext.text = "" + PlayerPrefs.GetInt("highscore");
        HStextposter.text =  PlayerPrefs.GetInt("highscore") + " POINTS";
       
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

    public void Menuprincipal()

    {
        SceneManager.LoadScene("RollballMEnu");   
    }

    public void ChooseDifficulty (int choice)
    {
        Choice.Scenarioactuelle = Choice.tableauscenrario[choice];
    }



}
