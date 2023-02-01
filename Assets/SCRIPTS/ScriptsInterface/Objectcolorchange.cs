using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectcolorchange : MonoBehaviour,IUsableObject

{
   // private bool ColorChange = false;
   // private Color basecolor;
    private Color[] Couleurs = { Color.magenta, Color.yellow, Color.blue, Color.green, Color.cyan,Color.white, };
    private int actualclor = -1 ; 
    public void UseObject()
    {
        actualclor++;
        if (actualclor>= Couleurs.Length)
        {
            actualclor = 0;
        }

        GetComponent<MeshRenderer>().material.SetColor("_Color", Couleurs[actualclor] ); 
                
        
        
        
        
        
        
        
        /*  if (ColorChange == false)
          {
              ColorChange = true;
              GetComponent<MeshRenderer>().material.SetColor("_Color", Color.magenta);
          }
          
          else if (ColorChange == true)
          {
              ColorChange = false;
              GetComponent<MeshRenderer>().material.color = basecolor;
          }*/
        
        

    }
    public void Start()
    {
       // basecolor = GetComponent<MeshRenderer>().material.GetColor("_Color");
    }
}