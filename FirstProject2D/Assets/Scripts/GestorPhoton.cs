using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GestorPhoton : MonoBehaviourPunCallbacks
{
    public GameObject[] EntryButtons;

    public GameObject Menu1;

    public GameObject MenuSalas;

    public GameObject textCargando; 

    private TypedLobby customLobby = new TypedLobby("customLobby", LobbyType.Default);

    private Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();

    static string PlayerNamePrefKey = "PlayerName";

    public InputField NameInputField;

    string RoomName = "place holder";


    // Start is called before the first frame update
    void Start()
    {
        if(!PhotonNetwork.IsConnected){
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.SendRate = 20;
            PhotonNetwork.SerializationRate = 10;
            PhotonNetwork.ConnectUsingSettings();
        }

        string DefaultName = "";
 
        if(NameInputField != null){
            if(PlayerPrefs.HasKey(PlayerNamePrefKey)){
                DefaultName = PlayerPrefs.GetString(PlayerNamePrefKey);
                NameInputField.text = DefaultName;
            }
        }
        PhotonNetwork.NickName = DefaultName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerEnteredRoom( Player newPlayer){
        print(newPlayer.NickName + "Has joined");
        
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >=2){
            PhotonNetwork.LoadLevel(2);  
        }
    }

    public override void OnConnectedToMaster(){
        print("connected to master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){
        //PhotonNetwork.JoinLobby(customLobby);
        print("connected to Lobby");
        Menu1.SetActive(true);
        textCargando.SetActive(false);
        
    }

    public void CreateRoom(){
        PhotonNetwork.CreateRoom(RoomName, new RoomOptions() {MaxPlayers = 2}, TypedLobby.Default );
    }

    public override void OnJoinedRoom(){
        print("Joined room");
        
    }

    public void GetRoomList(){
        Menu1.SetActive(false);
        MenuSalas.SetActive(true);
        print("tamaño"+ cachedRoomList.Count);
        RoomInfo[] RoomList = new RoomInfo[cachedRoomList.Count];
        int Position = 0;
        Dictionary<string, RoomInfo>.ValueCollection values = cachedRoomList.Values;  
        foreach (RoomInfo val in values)  {  
            RoomList[Position]=val;  
            Position = Position + 1;   
        }

        if(RoomList.Length > 0){
            
            for(int Index = 0; Index < RoomList.Length; ++Index){
                RoomInfo Room = RoomList[Index];
                GameObject Entry = EntryButtons[Index];
                Entry.SetActive(true);
                Text EntryText = Entry.GetComponentInChildren<Text>();
                EntryText.text = Room.Name;
            }

        }

    }

    private void UpdateCachedRoomList(List<RoomInfo> roomList)
    {
        for(int i=0; i<roomList.Count; i++)
        {
            RoomInfo info = roomList[i];
            if (info.RemovedFromList)
            {
                cachedRoomList.Remove(info.Name);
            }
            else
            {
                cachedRoomList[info.Name] = info;
            }
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateCachedRoomList(roomList);
    }

    public override void OnLeftLobby()
    {
        cachedRoomList.Clear();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        cachedRoomList.Clear();
    }

    public void JoinRoom(Text EntryText){
        PhotonNetwork.JoinRoom(EntryText.text);
    }

    public void SetPlayerName(string value){
        PhotonNetwork.NickName = value + " ";
        PlayerPrefs.SetString(PlayerNamePrefKey, value);

    }

    public void SetRoomName(string value){
        RoomName = value;
    }

}
