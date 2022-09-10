using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EVENTODEC1 : MonoBehaviour
{
    public static event Action Eventito2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Eventito2?.Invoke();
        }
    }
}
