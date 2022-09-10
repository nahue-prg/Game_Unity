using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    private float speed = 2f;
    //private Vector3 pos;
    private Vector3 direccion;
    public float distancia;
    private float recorrido=0;
    public bool recorridoPositivo;

    [SerializeField]
    private boton[] btn;
    private boton controlador;

    public string nombreActivador;
    private enum movimientoEje
    {
        x,
        y,
        z
    };

    public bool activo=false;

    [SerializeField]
    private movimientoEje movEje;

    public Vector3 Direccion1 { get => direccion; set => direccion = value; }
    public float Speed { get => speed; set => speed = value; }

    void Start()
    {
       // posInicial = transform.position;
        Direccion();
        ScriptController();
    }


   
    void Update()
    {
        chequearEstado();
        if (activo)move();
    }

    public void ScriptController()   //Consulta sobre el estado del boton (si es apretado o no) --> Seria mas optimo que el boton active este script al estar apretado
    {
        btn = FindObjectsOfType<boton>();

        foreach(boton boton in btn)
        {
            if (boton.name == nombreActivador)
            {
                controlador = boton;
            }
        }
    }
    
    public void move()
    {
         if (recorrido < distancia) 
        { 
         transform.Translate(direccion * speed * Time.deltaTime);
         recorrido += speed * Time.deltaTime;
        }
        else {
            recorrido = 0f;
            invertirSentido();
        }
    }



    public void chequearEstado()
    {
        if (controlador.accion)
        {
            activo = true;
          //  Debug.Log("Se activo!");
        }
        else
        {
            activo = false;
        }
    }




    public void invertirSentido()
    {
      //  Debug.Log("Invertir sentido");
        if (direccion.x != 0)
        {
            direccion.x *= -1f;
        }
        if (direccion.y != 0)
        {
            direccion.y *= -1f;
        }
        if (direccion.z != 0)
        {
            direccion.z *= -1f;
        }
    }

    public void Direccion()
    {
        float sentido;
        if (recorridoPositivo)
        {
            sentido = 1f;
        }
        else
        {
            sentido = -1f;
        }

        switch (movEje)
        {
            case movimientoEje.x:
                direccion = new Vector3(sentido, 0, 0);
                break;

            case movimientoEje.y:
                direccion = new Vector3(0, sentido, 0);
                break;
            case movimientoEje.z:
                direccion = new Vector3(0, 0, sentido);
                break;
        }


    }

}
