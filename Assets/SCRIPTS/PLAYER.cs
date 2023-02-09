using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAYER : MonoBehaviour
{
    public float UpmooveSpeed = -1.3f;
    public float DownmooveSpeed = 1.3f;
    public float LeftmooveSpeed = 1.3f;

    public float RightmooveSpeed = -1.3f;

    public int Score = 0;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text TimerText;
   [SerializeField] private TIMER Timerscipt;
    public AudioSource Maluseffect;
    public AudioSource Bonuseffect;
    public AudioSource Starseffect;
    public TIMER Timerscript;
    public MenuPause MenuPause;
   // [SerializeField] private ScenarioData _scenario;
    [SerializeField] private AppData _appData; 
    [SerializeField] private GameObject Ultramalus;
    public AudioSource UltramalusSound; 
   
    void Start()
    {
        Ultramalus.SetActive(false);
        if (_appData.Scenarioactuelle.UltraMalusSpawn == true)
        {
            Ultramalus.SetActive(true);
        }
        
    }


    void Update()
    {   
        Ultramalus.transform.Rotate(0f,1f,0f);
        
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

        if (Score > _appData.Scenarioactuelle.ScoreTarget && Timerscipt.Duration == 0)
        {
            if (Score> PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", Score); 
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
          
        }

        //loose screen
        if (Score < _appData.Scenarioactuelle.ScoreTarget && Timerscipt.Duration == 0)
        {
            if (Score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", Score); 
            }
            SceneManager.LoadScene("LooseMenu");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            MenuPause.Stop();
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Score = Score + _appData.Scenarioactuelle.BonusValue ;
            ScoreText.text = "SCORE : " + Score.ToString() + " / " + _appData.Scenarioactuelle.ScoreTargettext ;
            Bonuseffect.Play();
        }
     
        else if (other.gameObject.CompareTag("MalusTarget"))

        {
            Score = Score + _appData.Scenarioactuelle.MalusValue;
            ScoreText.text =  "SCORE : " + Score.ToString() + " / " + _appData.Scenarioactuelle.ScoreTargettext;;
            Maluseffect.Play();
        }
        else if (other.gameObject.CompareTag("StarsBonus"))

        {
           Timerscipt.Duration = Timerscipt.Duration + 10f;
            TimerText.text = "TIME LEFT : " + Mathf.Floor(Timerscipt.Duration).ToString();
            Starseffect.Play();
        } 
        else if (other.gameObject.CompareTag("UltraMalus"))

        {
            UltramalusSound.Play();
            SceneManager.LoadScene("LooseMenu");
            
        }    
        
    }
    
    
    
    
    
    
    
    
    
}