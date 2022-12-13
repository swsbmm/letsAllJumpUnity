using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime; 

public class CamaraController : MonoBehaviour
{

    public GameObject target;
    private bool found = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(!found){
            if (PhotonNetwork.IsMasterClient)
            {   
                target = GameObject.Find("Ryan(Clone)");
            }
            else
            {   
                target = GameObject.Find("Kevin(Clone)");
            }
            found = true;
        }
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
