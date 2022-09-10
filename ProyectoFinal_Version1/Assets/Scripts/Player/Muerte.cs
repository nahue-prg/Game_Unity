using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour
{
    Ragdoll ragdoll;
    public float alturaMuerte=-15f;
    public GameObject manager;
    //private GameManager manag;
    public bool colisiona=false;
    private bool primero = false;

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
      //  manag = manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        condicionAltura();
      
    }

    public void condicionAltura()
    {

        if (transform.position.y <= alturaMuerte)
        {
            if (!primero) {
                primero = true;
                Debug.Log("Suma una vida perdida");
                ragdoll.getRagdoll = true;
                ragdoll.cambio = true;
            }
        }
       else
        {
            primero = false;
        }
    
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ActiveRagdoll"))
        {
          //  manag.scoreLostLifes++;
            Debug.Log("Suma una vida perdida");
            ragdoll.getRagdoll = true;
            ragdoll.cambio = true;
            colisiona = true;

        }
    }

 


}
