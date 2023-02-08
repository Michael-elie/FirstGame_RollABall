using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
 public struct ScenariosData
 {
   
 }

[CreateAssetMenu(menuName = "New Scenario")] 
public class ScenarioData: ScriptableObject
   {
       //public int Score;
       public GameObject BonusStars;
       public GameObject malusultra;
     //  public float GameDuration;
       public int MalusNumber;
       public int BonusNumber;
       public int MalusValue;
       public int BonusValue;
       public int StarNumber;
       public int ScoreTarget;
   }

