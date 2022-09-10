using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    Ragdoll ragdoll;
    Respawn respawn_;
    public bool dontDestroyOnLoad;
    public GameObject PJ;
    public Vector3 posInicial;
    private static Vector3 puntoControl;
    private static bool puntoControl_ = false;

    public static int  scoreLostLifes = 0;  //Vidas perdidas

    public static GameManager Instance { get => instance; set => instance = value; }
    public bool PuntoControl_ { get => puntoControl_; set => puntoControl_ = value; }
    public Vector3 PuntoControl1 { get => puntoControl; set => puntoControl = value; }

    Temporizador temporizador;   //Primero se activa y luego se utiliza

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (dontDestroyOnLoad){
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
       

    }
    void Start()
    {
        temporizador = GetComponent<Temporizador>();
        ragdoll = PJ.GetComponent<Ragdoll>();
        respawn_ = PJ.GetComponent<Respawn>();
        PuntoControl();
      //  Debug.Log(puntoControl_.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        control();
    }

    public void control()
    {
        if (ragdoll.getRagdoll)

        {

            temporizador.activar(3f);

            if (temporizador.contando())
            {
                scoreLostLifes++;
                restartGame();
                //ragdoll.cambio = true;
                //ragdoll.getRagdoll = false;
              
                
            }
        }
    }

    public void PuntoControl()
    {
        
        if (puntoControl_)
        {
            PJ.transform.position = puntoControl;

        }

        else
        {
            PJ.transform.position = posInicial;
        }
    }



    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }

}
