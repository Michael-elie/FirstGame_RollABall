using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class TIMER : MonoBehaviour
{
    public float Duration = 60f;
    [SerializeField] private TMP_Text TimerText;
    public PLAYER Scorescript;
    
    private void Start()
    {
        
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
       
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
          
      }

      //loose screen
        if (Scorescript.Score <= 50 && Duration == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        
        
    }
    



}
