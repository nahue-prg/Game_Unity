using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarPelotas : MonoBehaviour
{
    List<GameObject> JuntandoCosas = new List<GameObject>();
    Stack pila = new Stack();

    void Start()
    {
        
    }

    void Update()
    {
        historialComidas();
        escupiendoComidas();
    }

    public void historialComidas()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            int cont = 0;
            Debug.Log("Te has comido los siguientes gameObjects: ");
            foreach (GameObject go in JuntandoCosas)
            {
                Debug.Log(gameObject.name.ToString());
                cont++;
            }
            Debug.Log("Son un total de " + cont.ToString() + " gameObjects.");
        }
    }

    public void escupiendoComidas()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pila.Count != 0)
            {
                var pelota = pila.Pop() as GameObject;   //Expulsando pelota
                pelota.SetActive(true);    
                pelota.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                pelota.transform.rotation = transform.rotation;
                pelota.transform.Translate(0, 0, 1.5f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pelota")
        {
            JuntandoCosas.Add(collision.gameObject);  //Lo agrega al historial de comidas
            pila.Push(collision.gameObject);         //Lo agrega a la pila
            collision.gameObject.SetActive(false);   //Lo hace desaparecer 
        }
    }






}
