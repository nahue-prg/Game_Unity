using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventos1 : MonoBehaviour
{
    [SerializeField] public UnityEvent evento;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        evento.Invoke();
        Debug.Log("El jugador salio del trigger");
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }



}
