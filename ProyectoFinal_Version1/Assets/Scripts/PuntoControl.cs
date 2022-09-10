using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoControl : MonoBehaviour
{
    // Start is called before the first frame update

    
    GameObject PJ;
    public GameObject manager;
    private GameManager manag;

    void Start()
    {
        name = gameObject.name;
        manag = manager.GetComponent<GameManager>(); 
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PJ")
        {
            manag.PuntoControl1 = transform.position;
            manag.PuntoControl_ = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "PJ")
        {
            manag.PuntoControl1 = transform.position;
            manag.PuntoControl_ = true;

        }
    }

    
}
