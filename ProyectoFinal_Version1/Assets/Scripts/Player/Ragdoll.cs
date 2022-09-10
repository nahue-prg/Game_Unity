using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Collider[] ragdollColliders;
    Rigidbody[] mainRigibodies;
    public Animator anim;
    public CapsuleCollider myCollider;
    public Rigidbody myRigidbody;
    public GameObject rig;
    public CapsuleCollider groundChecker;
    public bool getRagdoll;
    public bool cambio=false;
    PlayerMovement playerMovement;  //Como esta en el mismo objeto la referenciamos sin nisiquiera buscarla
  

    void Start()
    {
        
        GetRagdollData();
        RadgollOff();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cambio)
        {
            if (getRagdoll) RadgollOn();
            else RadgollOff();
            cambio = false;
        }
    }


    void GetRagdollData()
    {
        ragdollColliders = rig.GetComponentsInChildren<Collider>();
        mainRigibodies = rig.GetComponentsInChildren<Rigidbody>();
    }

    void RadgollOff()//caminando, animator andando
    {
        playerMovement = GetComponent<PlayerMovement>();

        foreach (Collider col in ragdollColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in mainRigibodies)
        {
            rigid.isKinematic = true;
        }
        anim.enabled = true;
        myCollider.enabled = true;
        myRigidbody.isKinematic = false;
        groundChecker.enabled = true;
        playerMovement.enabled = true;
        
        
       

        
    }


    void RadgollOn()
    {

       
        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in mainRigibodies)
        {
            rigid.isKinematic = false;
        }
        anim.enabled = false;
        myCollider.enabled = false;
        myRigidbody.isKinematic = true;
       playerMovement.enabled = false;
        groundChecker.enabled = false;

    }



}
