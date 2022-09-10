using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informes : MonoBehaviour
{
    public Data data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch();
    }

    public void Touch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(data.Tiempo.ToString());
            Debug.Log("Se activa al colisionar con" + data.CollisionName.ToString());
        }
    }
}
