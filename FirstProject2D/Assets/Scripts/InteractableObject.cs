using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    private bool z_Interacted = false;
    public GameObject y_gameObject;

    protected override void OnCollided(GameObject collidedObject){

        if(Input.GetKey(KeyCode.E)){
            OnInteract(collidedObject);
        }    
    }

    protected virtual void OnInteract(GameObject collidedObject){

        if(!z_Interacted){
            z_Interacted = true;
            y_gameObject.SetActive(false);
            changeImageObjectIteracted();
        }

    }

    private void changeImageObjectIteracted(){
            if(this.GetComponent<Palanca>()== true){
                this.GetComponent<Palanca>().activated = true;
            }
    }
    
}
