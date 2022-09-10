using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    public GameObject sonidoExplosion;
    public GameObject efectoExplosion; //Sistema de particulas
    public float speedMisil = 70f;
    public float radius = 20f;
    public float explosionForce = 10f;
    public float segundosActivo=12f;
    Temporizador temp;

    void Start()
    {
        temp = GetComponent<Temporizador>();

        temp.comenzarConteo();

        //Invoke("explotarGranada", delay);
    }

    void Update()
    {
        move();
        verificarConteo();
    }


    private void OnCollisionEnter(Collision collision)
    {
        explotarGranada();
        if (collision.gameObject.tag == "PJ")
        {
            try { 
            var rg = collision.gameObject.GetComponent<Ragdoll>();
            rg.cambio = true;
            rg.getRagdoll = true;
            }
            catch
            {
                
            }
        }
    }

    public void move()
    {
        transform.Translate(new Vector3 (0, 0, 1) * speedMisil * Time.deltaTime);
       //transform.Rotate(new Vector3(0, 10, 0) * speedMisil * Time.deltaTime);
    }

    public void verificarConteo()
    {
        if (temp.contarTiempo()>=segundosActivo)
        {
            Debug.Log(temp.contarTiempo().ToString());
            explotarGranada();
        }
    }

    void explotarGranada()
    {
        //Chequear colliders cercanos y guardarlos en un array

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

       Instantiate(sonidoExplosion);

        //Luego de chequearlos debemos aplicar fuerza sobre los colliders detectados.
        foreach (Collider cl in colliders)
        {
            Rigidbody rb = cl.GetComponent<Rigidbody>();

            if (rb != null)
            {

                rb.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
            }
            //Instanciar el sistema de particulas
            var particle = Instantiate(efectoExplosion, transform.position, transform.rotation);
            Destroy(particle, 2f);
            
            //Destruir granada
            
            Destroy(gameObject);
           
        }

        

    }

}
