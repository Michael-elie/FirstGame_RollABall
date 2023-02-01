using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAcradeMAchine : MonoBehaviour,  IUsableObject
{
    public Mesh[]  ArcadeMachine = {};
    private int actualmachine = -1;
    
    public void UseObject()
    {
        actualmachine++;
        if (actualmachine>= ArcadeMachine.Length)
        {
            actualmachine = 0;
        }

        GetComponent<MeshFilter>().mesh = ArcadeMachine[actualmachine];

    }
}
