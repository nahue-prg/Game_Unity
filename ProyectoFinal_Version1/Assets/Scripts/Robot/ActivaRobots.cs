using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaRobots : MonoBehaviour
{
    //public GameObject[] Robots;
    public Disparar[] disparar;

    // Start is called before the first frame update
    void Start()
    {
 
       // disparar = Robots[0].GetComponent<Disparar>();
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PJ")
            foreach (Disparar d in disparar)
                d.disparosActivados = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PJ")
            foreach (Disparar d in disparar)
                d.disparosActivados = false;
    }
}
