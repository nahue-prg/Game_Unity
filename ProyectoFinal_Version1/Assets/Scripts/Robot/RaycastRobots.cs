using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastRobots : Raycast
{
    Disparar disparar;
    EnemyFollow move;
    public bool seguirAjugador = true;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<EnemyFollow>();
        disparar = GetComponent<Disparar>();
    }

    // Update is called once per frame
    void Update()
    {

        Detected();

    }

    public void Detected()
    {
        if (raycast())
        {
            if (seguirAjugador)
            {
                move.enabled = true;

            }
            disparar.disparosActivados = true;
        }
    }

   
}
