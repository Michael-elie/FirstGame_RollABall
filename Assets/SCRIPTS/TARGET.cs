using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TARGET : MonoBehaviour
{
    public float RotationSpeed = 1f;
    public SPAWN_TARGET SpawnerScript;
    
    void Update()
    {
        transform.Rotate(0f,RotationSpeed,0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SpawnerScript.respawn();
            Destroy(gameObject);
            
        }  
    }

  
    
       
    
}
