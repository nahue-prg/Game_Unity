using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Eventoc3 : MonoBehaviour
{
    public static event Action Eventito3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Eventito3?.Invoke();
        }
    }
}
