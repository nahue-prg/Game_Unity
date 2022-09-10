using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton : MonoBehaviour
{
    public float speed = 3f;
    public float posFinal= 36f;

    public bool accion=false;
    public string nombre;
    public GameObject sonidoBoton;

    //public Transform Piso;
    private Vector3 posInicial;
    private bool atroden = false;

    public boton(string nombre="null")    
    {
        this.nombre = nombre;
    }

    public bool Accion { get => accion; set => accion = value; }
    public string Nombre { get => nombre; set => nombre = value; }

    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        accionar();
    }

    /* private void OnCollisionStay(Collision collision)
     {

      if (collision.gameObject.tag == "PJ")
         {
             Debug.Log("collision");
             if (Input.GetKeyDown(KeyCode.E))
                 accionF();

         }  


     }*/

    public void accionar() 
        {
        if (atroden)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                accionF();
                var boton = Instantiate(sonidoBoton) ;
            }
                
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PJ")
        {

            UIJuego.mostrar = true;
            atroden = true;
            
        }
       
       }


    private void OnTriggerExit(Collider other)
    {
        UIJuego.mostrar = false;
        atroden = false;
    }

    public void accionF ()
        {
       if (accion)
            accion = false;
        else
            accion = true;
       }





}


