using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROTATE : MonoBehaviour
{
    public float RotationSpeed = 1f;

    void Start()
    {

    }


    void Update()
    {
        transform.Rotate(0f, RotationSpeed, 0f);





    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);




        }
    }
}