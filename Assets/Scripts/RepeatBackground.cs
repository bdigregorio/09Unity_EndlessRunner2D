using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()    
    {
        if (transform.position.x < startPosition.x - 50) 
        {
            transform.position = startPosition;
        }   
    }
}
