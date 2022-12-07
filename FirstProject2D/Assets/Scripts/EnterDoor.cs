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
            }
        }
    }


    private void loadNextLevel(int level){
        PhotonNetwork.LoadLevel(level);
    }

    void OnLevelWasLoaded(int level)
    {

        switch(level) 
            {
            case 1:
                break;
            case 2:
                if (PhotonNetwork.IsMasterClient)
                    {   
                        PhotonNetwork.Instantiate("Ryan", new Vector2(-5,-2.6f), Quaternion.identity); 
                    }
                    else
                    {   
                        PhotonNetwork.Instantiate("Kevin", new Vector2(-5,-2.6f), Quaternion.identity); 
                    }
                break;
            case 3:
                if (PhotonNetwork.IsMasterClient)
                    {   
                        print("PERO SI LOS INSTANCIA O QUÉ");
                        PhotonNetwork.Instantiate("Ryan", new Vector2(-14.5f,-3.2f), Quaternion.identity); 
                    }
                    else
                    {   
                        print("PERO SI LOS INSTANCIA O QUÉ 2");
                        PhotonNetwork.Instantiate("Kevin", new Vector2(-13.0f,-3.2f), Quaternion.identity); 
                    }
                break;
            default:
                // code block
                break;
            }
        
    }
}
