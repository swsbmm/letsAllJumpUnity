using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime; 

public class ManageScene : MonoBehaviour
{
    // called zero
    void Awake()
    {
        Debug.Log("Awake");
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        switch(scene.name) 
            {
            case "":
                break;
            case "Level5":
                print("level 5 is loaded");
                if (PhotonNetwork.IsMasterClient)
                    {   
                        print("instantiating Ryan");
                        PhotonNetwork.Instantiate("Ryan", new Vector2(-5,-2.6f), Quaternion.identity); 
                    }
                    else
                    {   
                        print("instantiating Kevin");
                        PhotonNetwork.Instantiate("Kevin", new Vector2(-3,-2.6f), Quaternion.identity); 
                    }
                break;
            case "Level3":
                print("level 6 is loaded");
                if (PhotonNetwork.IsMasterClient)
                    {   
                        PhotonNetwork.Instantiate("Ryan", new Vector2(-13.0f,-3.2f), Quaternion.identity); 
                    }
                    else
                    {   
                        PhotonNetwork.Instantiate("Kevin", new Vector2(16.28f,-3.2f), Quaternion.identity); 
                    }
                break;
            default:
                // code block
                break;
            }

    }

    // called third
    void Start()
    {
        Debug.Log("Start");
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        //SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}