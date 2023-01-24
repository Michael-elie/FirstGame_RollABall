using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectcolorchange : MonoBehaviour,IUsableObject
{
    public void UseObject()
    {
        GetComponent<MeshRenderer>().material.SetColor("BaseColor", Color.magenta);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}