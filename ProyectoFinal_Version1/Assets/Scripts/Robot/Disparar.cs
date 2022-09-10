using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{

    public bool disparosActivados = false;
    public float tiempoEntreDisparos = 3f;
    public int cantidadDisparos = 6;
    public GameObject Misil;
    private Temporizador temp;
    private float SegundoUltimo;
    // Start is called before the first frame update
    void Start()
    {
        temp = GetComponent<Temporizador>();
        temp.comenzarConteo();
       
    }

    
// Update is called once per frame
void Update()
    {
        disparar();
    }
    public void disparar()
    {
        if (disparosActivados)
        {
            if ((SegundoUltimo + tiempoEntreDisparos) <= temp.contarTiempo())
            {
                SegundoUltimo = temp.contarTiempo();
                for (int i = 0; i < cantidadDisparos - 1; i++)
                {
                    CrearMisil();
                }
            }
        }
    }

    void CrearMisil()
{
        var balita = Instantiate(Misil, transform.position + new Vector3(Random.Range(-0.6f, 0.6f), 0, Random.Range(-0.6f, 0.6f)),transform.rotation);
}

}
