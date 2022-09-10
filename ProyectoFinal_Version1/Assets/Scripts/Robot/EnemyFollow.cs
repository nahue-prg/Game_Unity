using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform jugador;
   

    [SerializeField]     //ES PRIVADA PERO MODIFICARLA EN EL EDITOR
    public float enemySpeed = 2f;
    private float  VelocidadM=0f;
    public float distanciaFrenado = 5f;
    public bool activo;
    
    enum tipoSeguimiento
    {
        LookAt,
        Lerp,
        Slerp,
        SeguirAJugador,
        Quaternion
    }

    [SerializeField]
    tipoSeguimiento Tipseguimiento;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chequearDistanciaJugador();

        
        Follow();
       
       
    }

    public void Follow()
    {

        if (activo)
        {

        
        switch (Tipseguimiento)
        {
            case tipoSeguimiento.SeguirAJugador:
                seguirAlJugador();
                break;
            case tipoSeguimiento.Slerp:
                seguirSLerp();
                break;
            case tipoSeguimiento.Lerp:
                lerp();
                break;
            case tipoSeguimiento.LookAt:
                LookAt();
                break;
            case tipoSeguimiento.Quaternion:
                lookAtPlaerQuat();
                break;
    }
        }

    }


    void chequearDistanciaJugador()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);
        if (distancia <= distanciaFrenado)
        {
            VelocidadM = 0;
            LookAt();
        }
        else { VelocidadM = enemySpeed; }


    }

    public void lerp()
    {
        transform.position = Vector3.Lerp(transform.position, jugador.position, enemySpeed * Time.deltaTime);
    }



    
    void lookAtPlaerQuat()
    {
        Quaternion rot = Quaternion.LookRotation(jugador.position - transform.position);
        transform.rotation = rot;

    }
    
    
    void LookAt()
    {
        transform.LookAt(jugador);
    }

    
    void seguirAlJugador()
    {
        transform.position = Vector3.MoveTowards(transform.position, jugador.position, enemySpeed * Time.deltaTime);
    }

    void seguirSLerp()
    {
        transform.position = Vector3.Slerp(transform.position, jugador.position, VelocidadM * Time.deltaTime);
    }
}
