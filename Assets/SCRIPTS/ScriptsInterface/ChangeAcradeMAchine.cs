using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAcradeMAchine : MonoBehaviour,  IUsableObject
{
    public GameObject[]  ArcadeMachine = {};
    private int actualmachine = -1;
    private GameObject objectspawnsed ;

    private void Start()
    {
        SpawnNewPrefab();
    }

    private void SpawnNewPrefab()
    {
        if (objectspawnsed != null)
        {
           Destroy(objectspawnsed); 
        }
        actualmachine++;
        if (actualmachine>= ArcadeMachine.Length)
        {
            actualmachine = 0;
        }
        
        objectspawnsed =  Instantiate(ArcadeMachine[actualmachine],transform.position,transform.rotation );
    }

    public void UseObject()
    {
        SpawnNewPrefab();


    }
}
