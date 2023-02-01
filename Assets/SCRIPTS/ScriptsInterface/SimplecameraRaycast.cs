using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SimplecameraRaycast : MonoBehaviour
{
    private bool ColliderOn = false;
    [SerializeField] private Image _reticule;
    [SerializeField] private Color Colorreticule;
    private GameObject hitgameobject;

void Update()
    {
      /*  RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, 6f))
        {
            if (hit.collider.GetComponent<IUsableObject>() != null && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(hit.collider.gameObject.name);

                hit.collider.GetComponent<IUsableObject>().UseObject();
                
            }
        
       
        }*/
      
      
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, 6f))
        {
            if (hit.collider.GetComponent<IUsableObject>() != null )
            {
               // hit.collider.GetComponent<IUsableObject>().UseObject();
                _reticule.color = Color.white;
            }
        
       
        }
      if (ColliderOn == true && Input.GetKeyDown(KeyCode.E))
      { 
          hitgameobject.GetComponent<IUsableObject>().UseObject();
      }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable") )
        {
            ColliderOn = true;
            hitgameobject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable") )
        {
            ColliderOn = false;
        }
    }
}