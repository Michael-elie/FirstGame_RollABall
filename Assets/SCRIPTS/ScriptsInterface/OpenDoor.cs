using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IUsableObject
{
    public MOVEMENT_FPS MovementFPS;
    public bool DoorisOpen = false;

    public void UseObject()
    {
        Debug.Log("Test OK");

        if (DoorisOpen == false)
        {
            DoorisOpen = true;
            MovementFPS.doorAnimator.SetBool("IsOpen",true);
        }
        
        else if (DoorisOpen == true)
        {
            DoorisOpen = false;
            MovementFPS.doorAnimator.SetBool("IsOpen",false);
        }

        
    }
}
