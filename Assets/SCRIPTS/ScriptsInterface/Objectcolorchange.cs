using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectcolorchange : MonoBehaviour,IUsableObject

{
    private bool ColorChange = false;
    private Color basecolor; 
    public void UseObject()
    {
        
        if (ColorChange == false)
        {
            ColorChange = true;
            GetComponent<MeshRenderer>().material.SetColor("_Color", Color.magenta);
        }
        
        else if (ColorChange == true)
        {
            ColorChange = false;
            GetComponent<MeshRenderer>().material.color = basecolor;
        }
        
        

    }
    public void Start()
    {
        basecolor = GetComponent<MeshRenderer>().material.GetColor("_Color");
    }
}