using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InteractableObject : CollidableObject
{
    private PhotonView PV;
    private bool z_Interacted = false;
    public GameObject y_gameObject;

    protected override void Start(){
        z_Collider = GetComponent<Collider2D>();
        PV = GetComponent<PhotonView>();
    }

    protected override void OnCollided(GameObject collidedObject){

        if(Input.GetKey(KeyCode.E)){
            OnInteract(collidedObject);
        }    
    }
    
    protected virtual void OnInteract(GameObject collidedObject){

        if(!z_Interacted){
            z_Interacted = true;
            PV.RPC("changeStateOfObject", RpcTarget.All, !z_Interacted);
            changeImageObjectIteracted();
        }

    }

    private void changeImageObjectIteracted(){
            if(this.GetComponent<Palanca>()== true){
                this.GetComponent<Palanca>().activate(true);
            }
    }

    [PunRPC]
    private void changeStateOfObject(bool state){
            y_gameObject.SetActive(state);
    }
    
}
