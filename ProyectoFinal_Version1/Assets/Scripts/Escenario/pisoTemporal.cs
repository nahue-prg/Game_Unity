using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisoTemporal : MonoBehaviour
{
    // Start is called before the first frame update
    public float esperaSegundos = 2f;
    private float tiempo=0;
    private bool colision = false;
    public Rigidbody rg;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colision)
        {
            cuentaRegresiva();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "PJ")
        {
            colision = true;
        }
       
    }

    public void cuentaRegresiva()
    {
        if (temporizador())
        {

            rg.constraints = new RigidbodyConstraints();  //Se le asigna nuevas restricciones para que no tenga ninguna aplicada
            rg.useGravity = true;
        }

    }


    public bool temporizador()
    {
        if (tiempo < esperaSegundos)
        {
            tiempo += Time.deltaTime;
            return false;
        }
        else
        {
            tiempo = 0;
            return true;
        }
    }



}
