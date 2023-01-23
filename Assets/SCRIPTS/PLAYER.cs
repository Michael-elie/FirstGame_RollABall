using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAYER : MonoBehaviour
{
    public float UpmooveSpeed = -1f;
    public float DownmooveSpeed = 1f;
    public float LeftmooveSpeed = 1f;

    public float RightmooveSpeed = -1f;
    

    public int Score = 0;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text TimerText;
    [SerializeField] private TIMER Timerscipt;
    public AudioSource Maluseffect;
    public AudioSource Bonuseffect;
    public AudioSource Starseffect;
    public TIMER Timerscript;
   
    void Start()
    {
       
    }


    void Update()
    {   
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(LeftmooveSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(RightmooveSpeed, 0, 0);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, UpmooveSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, DownmooveSpeed);
        }

        if (Score >= 50 && Timerscipt.Duration == 0)
        {
            if (Score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", Score); 
            }
            SceneManager.LoadScene("RollballWinMenu");
        
          
        }

        //loose screen
        if (Score <= 50 && Timerscipt.Duration == 0)
        {
            if (Score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", Score); 
            }
            SceneManager.LoadScene("RollballLooseMenu");
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Score++ ;
            ScoreText.text = "SCORE : " + Score.ToString() + " / 50";
            Bonuseffect.Play();
        }
     
        else if (other.gameObject.CompareTag("MalusTarget")) 

        {
            Score--;
            ScoreText.text =  "SCORE : " + Score.ToString() + " / 50";;
            Maluseffect.Play();
        }
        else if (other.gameObject.CompareTag("StarsBonus"))

        {
            Timerscipt.Duration = Timerscipt.Duration +10f;
            TimerText.text = "TIME LEFT : " + Mathf.Floor(Timerscipt.Duration).ToString();
            Starseffect.Play();
        }    
        
    }
    
    
    
    
    
    
    
    
    
}