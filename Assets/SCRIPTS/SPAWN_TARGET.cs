using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SPAWN_TARGET : MonoBehaviour

{

 public GameObject Target;



    IEnumerator DelayBeforeSpawn()
    {

        yield return new WaitForSeconds(0.5f);
        Vector3 RadomSpawnPosition = new Vector3(Random.Range(-3.55f,3.55f), 1.936722f, Random.Range(-3.55f, 3.55f));
        GameObject temp = Instantiate(Target, RadomSpawnPosition, Quaternion.identity);
        temp.GetComponent<TARGET>().SpawnerScript = this;

    }
    
    public void respawn (string name)

        {
            if (name == gameObject.name)
            {
                StartCoroutine(DelayBeforeSpawn());
            }
           
        }

   private void OnEnable()
   { 
       TARGET.OnTargetTouched += respawn;
   }
   
   private void OnDisable()
   {
       TARGET.OnTargetTouched -= respawn;
   }
   
   
   
   
   
}

