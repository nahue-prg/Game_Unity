using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EVENTODEC2 : MonoBehaviour
{
    public static event Action Eventito;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Eventito?.Invoke();
        }
    }
}
