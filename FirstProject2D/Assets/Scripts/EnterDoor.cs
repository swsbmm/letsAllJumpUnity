using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime; 

public class EnterDoor : MonoBehaviour
{
    private bool enterAllowed;
    private int sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BlueDoor>())
        {
            sceneToLoad = 3;
            enterAllowed = true;
        }
        else if (collision.GetComponent<BrownDoor>())
        {
            sceneToLoad = 4;
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BlueDoor>() || collision.GetComponent<BrownDoor>())
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKeyDown(KeyCode.Return))
        {
            //loadNextLevel(sceneToLoad);
            if(PhotonNetwork.IsMasterClient){
                PhotonNetwork.LoadLevel(sceneToLoad);    
                //placePlayers(sceneToLoad);
            }
        }
    }


    private void loadNextLevel(int level){
        PhotonNetwork.LoadLevel(level);
    }


}
