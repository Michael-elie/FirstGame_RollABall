using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TIMER : MonoBehaviour
{
    public float Duration = 60f;
   // private float Timer;
    [SerializeField] private TMP_Text TimerText;
    public PLAYER Scorescript;
    public GameObject GAMEOVER;
    public GameObject GAMEOVER_2;
    public GameObject YOUWIN;
     public GameObject YOUWIN_2;

    public AudioSource Gamesong;
    public AudioSource WINSONG;
    public AudioSource LOOSESONG; 
    private void Start()
    {
        GAMEOVER.gameObject.SetActive(false);  
        GAMEOVER_2.gameObject.SetActive(false);  
        YOUWIN.gameObject.SetActive(false);  
       YOUWIN_2.gameObject.SetActive(false);  
       
        
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void restart ()

    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
    }

    void Update()
    
    { 
     
        
        // Timer -= Time.deltaTime;
        // if (Timer >= Duration)
        //
        //     Timer = 0;
        //
        // TimerText.text = Timer.ToString();

        if (Duration > 0)
        {
            Duration -= Time.deltaTime;
        }
        else
        {
            Duration = 0; 

        }
        
        TimerText.text = "TIME LEFT : " + Mathf.Floor(Duration).ToString();


      // win screen   
      if (Scorescript.Score >= 50 && Duration == 0)
      {
          Gamesong.Stop();
          WINSONG.Play();
          YOUWIN.gameObject.SetActive(true);
          


          if (Input.GetKeyUp(KeyCode.DownArrow))
          {
              YOUWIN.gameObject.SetActive(false);
              YOUWIN_2.gameObject.SetActive(true);


              if (Input.GetKeyUp(KeyCode.Return))
              {
                  Exit();
              }
          }

          if (Input.GetKeyUp(KeyCode.UpArrow))
          {

              YOUWIN.gameObject.SetActive(true);
              YOUWIN_2.gameObject.SetActive(false);


              if (Input.GetKeyUp(KeyCode.Return))
              {
                  restart();
              }

          }
      }

      //loose screen
        if (Scorescript.Score <= 50 && Duration == 0)
        {
            Gamesong.Stop();
            LOOSESONG.Play();
            GAMEOVER.gameObject.SetActive(true);


            if (Input.GetKeyUp(KeyCode.DownArrow))

            {
                GAMEOVER.gameObject.SetActive(false);
                GAMEOVER_2.gameObject.SetActive(true);
                

                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Exit();
                }
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))

            {
                GAMEOVER.gameObject.SetActive(true);
                GAMEOVER_2.gameObject.SetActive(false);
               



                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                { 
                   restart();
                }
            }

        }
        
    }
    



}
