using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;
    public GameObject lobbypanel;

    #region unity Methods

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;   
    }
    void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        lobbypanel.SetActive(false);
    }

    void Update()
    {
        
    }
    #endregion

    #region public Methods
    public void ConnectToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            ConnectionStatusPanel.SetActive(true);
            EnterGamePanel.SetActive(false);
        }
    }

    public void JoinRandomRoom() 
    {
        PhotonNetwork.JoinRandomRoom();
    }
    #endregion


    #region Photon Callbacks
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName +" connect the server");
        lobbypanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
    }

    
    public override void OnConnected()
    {
        Debug.Log("connect the internet");     
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined to"+ PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    #endregion

    #region Private methods
    void CreateAndJoinRoom() 
    {
        RoomOptions roomOptions = new RoomOptions();
        string randomRoomName ="Room" + Random.Range(0,10000);
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(randomRoomName,roomOptions);
    }
    #endregion
}
