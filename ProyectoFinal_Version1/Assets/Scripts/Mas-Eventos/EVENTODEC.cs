using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EVENTODEC : MonoBehaviour
{
    public bool entro;
    public GameObject enemigo;

    public event Action eventoC;


    Disparar enm;

    // Start is called before the first frame update
    void Start()
    {
         enm = enemigo.GetComponent<Disparar>();
        eventoC += eventoInc;
    }

    public void eventoInc()
    {
        Debug.Log("suscripcion");
        if (entro) enm.disparosActivados = true;
        else enm.disparosActivados = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PJ")
        {
            entro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PJ")
        {
            entro = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
