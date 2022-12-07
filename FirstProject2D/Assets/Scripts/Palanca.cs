using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Palanca : MonoBehaviour
{
    public Sprite LiverActivate;
    public bool activated = false;
    private PhotonView PV;


    private void Start(){
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(activated){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LiverActivate;
        }
        
    }

    public void activate(bool activate){
        PV.RPC("changeState", RpcTarget.All, activate);
    }

    [PunRPC]
    private void changeState(bool state){
        activated = state;
    }

}
