using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{



    public float range = 1000f;
    public Vector3 direccion = new Vector3(0, 0, 1);
    public string tagAdetectar = "PJ";
    //Disparar disparar;
    //EnemyFollow move;
    //public bool seguirAjugador = true;



    void Start()
    {

      //  move = GetComponent<EnemyFollow>();
        //disparar = GetComponent<Disparar>();
    }

    // Update is called once per frame
    void Update()
    {
        raycast();
        
    }

   public  bool raycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direccion, out hit, range))
        {

            if (hit.transform.tag == tagAdetectar)
            {

                return true;

                /*
               if (seguirAjugador)
               {
                   move.enabled = true;

               }
                   disparar.disparosActivados = true;
               */
            }
            else return false;
        }
        else return false;
        
    }

}
