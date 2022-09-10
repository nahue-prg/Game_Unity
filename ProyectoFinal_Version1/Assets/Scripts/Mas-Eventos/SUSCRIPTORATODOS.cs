using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUSCRIPTORATODOS : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        EVENTODEC1.Eventito2 += informarPosicionJugador;
        EVENTODEC2.Eventito += informarSaltoJugador;
        Eventoc3.Eventito3 += saludar;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

 

    void informarPosicionJugador()
    {
        Debug.Log("Hola, mi posicion es: " + transform.position.ToString());
    }

    void informarSaltoJugador()
    {
        Debug.Log("Te vi saltar PJ!!!");
    }

    void saludar()
    {
        Debug.Log("Hola soy un GameObject y te saludo!!");
    }

    private void onDisable()
    {
        EVENTODEC1.Eventito2 += informarPosicionJugador;
        EVENTODEC2.Eventito += informarSaltoJugador;
        Eventoc3.Eventito3 += saludar;
    }
}
