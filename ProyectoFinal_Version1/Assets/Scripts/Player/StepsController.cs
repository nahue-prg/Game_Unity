using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsController : MonoBehaviour
{

    PlayerMovement playerMovement;
    private bool moveFloor = false;
    private float speed;
    private Vector3 direccion;

    public bool MoveFloor { get => moveFloor; set => moveFloor = value; }
    public float Speed { get => speed; set => speed = value; }
    public Vector3 Direccion { get => direccion; set => direccion = value; }

    /* transform.Translate(direccion * speed * Time.deltaTime);   -->>PARAMETROS DEL FLOORMOVE*/
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag != "PuntoControl")
        {
            playerMovement.canJump = true;


            if (other.gameObject.tag == "Piso_Move")
            {
                FloorMove script = other.gameObject.GetComponent<FloorMove>();   //Si colisiona con un piso en movimiento setea sus parametros

                if (script.activo) { 
                moveFloor = true;
                direccion = script.Direccion1;
                speed = script.Speed;
                }
            }
            else
            {
                moveFloor = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "PuntoControl")
        {
            playerMovement.canJump = false;
        }
    }


   /* private void OnCollisionStay(Collision collision)
    {
        
    }*/
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

*/
}
