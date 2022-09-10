using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public bool respawn = false;
    public Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        respawnear();
    }

    public void respawnear()
    {

        if (respawn)
        {
            transform.position = posicion;
            respawn = false;
        }
    }
}
