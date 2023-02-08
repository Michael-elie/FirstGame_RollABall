using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TARGET : MonoBehaviour
{
    public float RotationSpeed = 1f;
    public SPAWN_TARGET SpawnerScript;


  

    public delegate void TargetEvents(string name);

    public static event TargetEvents OnTargetTouched;
    void Update()
    {
        transform.Rotate(0f,RotationSpeed,0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // SpawnerScript.respawn();
            
            
           OnTargetTouched?.Invoke(SpawnerScript.gameObject.name);
            Destroy(gameObject);
            
        }  
    }

  
    
       
    
}
