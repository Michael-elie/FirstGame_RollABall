using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SimplecameraRaycast : MonoBehaviour
{


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit))
        {
            if (hit.collider.GetComponent<IUsableObject>() != null )
            {
                Debug.Log(hit.collider.gameObject.name);

                hit.collider.GetComponent<IUsableObject>().UseObject();
            }
        }
    }
}
