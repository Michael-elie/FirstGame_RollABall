using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SPAWN_STARS_BONUS : MonoBehaviour
{
    [SerializeField] public GameObject StarsBonus;
  //  [SerializeField] private float Timer = 60f;
    [SerializeField] private TIMER timerScript;
    private bool StarBonusLock = true;
    
    void Start()
    {
        StarsBonus.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (timerScript.Duration <=5f && StarBonusLock)
        {
            Vector3 RandomSpawnPosition = new Vector3(Random.Range(-3.55f,3.55f), 1.936722f, Random.Range(-3.55f, 3.55f));
            StarsBonus.transform.position = RandomSpawnPosition;
            StarsBonus.gameObject.SetActive(true);
            StarBonusLock = false;
        }
       
        

    }
       
    }
    

    




    
