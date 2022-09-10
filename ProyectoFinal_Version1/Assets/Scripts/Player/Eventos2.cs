using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventos2 : MonoBehaviour
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


    private void OnTriggerStay(Collider other)
    {
        evento.Invoke();
        Debug.Log("Se esta invocando el tercer evento de unity");
    }



}
