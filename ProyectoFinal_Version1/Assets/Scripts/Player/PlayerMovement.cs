using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float speedMovement = 2;
    public float speedRotation = 60;
    Animator anim;
    float x, y;

    Rigidbody rb;
    public float impulseJump = 15;
    public bool canJump;
    StepsController stpsCntrl;
  
   
    private Vector2 direccionUltima;
   
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        stpsCntrl = FindObjectOfType<StepsController>();   ///OJO FUNCIONA CON UN SOLO JUGADOR QUE UTILICE ESTE COMPONENTE --> Mas de un jugador puede traer el stepController de otro 
        //manager = FindObjectOfType<GameManager>();
    }
    void FixedUpdate()
    {
        move();
    }

    void Update()
    {
        parametros();
        movimientoSuelo();
       
    }

    void movimientoSuelo() { 

    if (stpsCntrl.MoveFloor)
        {
            transform.position+=(stpsCntrl.Direccion * stpsCntrl.Speed * Time.deltaTime);
        }
        /* transform.Translate(direccion * speed * Time.deltaTime);   -->>PARAMETROS DEL FLOORMOVE*/

    }

    

    void move()
    {
        if (canJump)
        {
            transform.Translate(0, 0, y * Time.deltaTime * speedMovement);
        }
        else                   ///no permite volver al jugador hacia atras estando ya en el aire -> Es llevado por la inercia del salto
        {
            //  transform.Translate(0, 0, direccionUltima.y * Time.deltaTime * speedMovement);

            transform.Translate(0, 0, y * Time.deltaTime * speedMovement);
        }

        transform.Rotate(0, x * Time.deltaTime * speedRotation, 0);
    }


    void parametros()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("SpeedX", x);
        anim.SetFloat("SpeedY", y);

        if (canJump == true)
        {

            direccionUltima.x = x;
            direccionUltima.y = y;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Jump", true);
                rb.AddForce(new Vector3(0, impulseJump, 0), ForceMode.Impulse);
            }
            anim.SetBool("Grounded", true);

        }
        else
        {
            Falling();
        }
    }

    void Falling()
    {
     
        anim.SetBool("Grounded", false);
        anim.SetBool("Jump", false);
    }

  

    /*
    public Rigidbody rb;
    public Animator anim;

    public float velocidad = 15f;
    public float salto = 5f;
    public float maxSpeed = 6f;


    private static float movHor = 0f;
    private static float movVer = 0f;
    private static bool movimiento = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        saltoPJ();    //En FixedUpDate da errores.

    }

    private void FixedUpdate()
    {
        move();
    }

    public void saltoPJ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0f, salto, 0f), ForceMode.Impulse);
        }
    }

    public void move()
    {
        movHor = Input.GetAxis("Horizontal");
        movVer = Input.GetAxis("Vertical");

        Vector3 movimientoPJ = new Vector3(movHor, 0, movVer);

        if (limitesVelocidad())
        { 
            if (movimiento == false)
            {
                rb.AddForce(movimientoPJ * velocidad *100);
            }
            else
            {
                rb.AddForce(movimientoPJ * velocidad);
            }
            
        }

        if (movVer == 0 && movHor == 0)
        {
            movimiento = false;
        }
        else
        {
            movimiento = true;
        }

        animaciones(movimientoPJ);
    }

    public void animaciones(Vector3 inputPlayer)
    {
        if (inputPlayer != Vector3.zero)
        {
            anim.SetBool("Running", true);

        }
        else
        {
            anim.SetBool("Running", false);
            
        }

    }

    public bool limitesVelocidad()    //Controla que no se exceda la velocidad maxima.  -->Intento fallido de controlar por adforce.. 
    {
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
            return false;
        }
        else if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);
            return false;
        }
        else if (rb.velocity.z > maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
            return false;
        }
        else if (rb.velocity.z < -maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);
            return false;
        }
        else return true;
    }



    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            if (!movimiento)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            if (!movimiento)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    */
}
