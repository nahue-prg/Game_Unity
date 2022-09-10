using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{

    private float tiempo;
    private bool activo = false;
    private bool contarSegundos = false;
    private float tiempoTrancurrido=0;
    private float cuentaSegundos=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contando();
        contarTiempo();
    }


    /// <summary>
    /// Se activa con  el metodo activar pasando como parametro la cantidad de segundos que va a contar.. luego devuelve true cuando el tiempo finalizo o false en el caso contrario
    /// </summary>
    /// <returns></returns>
    public bool contando()
    {
        if (activo)
        {

            if (tiempoTrancurrido < tiempo)
            {
                tiempoTrancurrido += Time.deltaTime;
                return false;
            }
            else
            {
                tiempoTrancurrido = 0;
                activo = false;
                tiempo = 0;
                return true;
            }
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Metodo primario para activar el contador de tiempo (ContarTiempo) Devuelve la cantidad de segundos y milisegundos acumulados en float 
    /// </summary>
    public void comenzarConteo()
    {
        contarSegundos = true;
    }

    /// <summary>
    /// Devuelve la cantidad de tiempo transcurrido desde que se active en cada frame (Primero debe invocarse ComenzarConteo)
    /// </summary>
    /// <returns></returns>
    public float contarTiempo()
    {
        if (contarSegundos)
        {
            cuentaSegundos += Time.deltaTime;
           

        }
        else
        {
          cuentaSegundos = 0f;
        }
        return cuentaSegundos;
    }


    /// <summary>
    /// Metodo primario para activar el temporizador Contando()
    /// </summary>
    /// <param name="tiempo"></param>
   public void activar(float tiempo)
    {
        activo = true;
        this.tiempo = tiempo;
    }
}
