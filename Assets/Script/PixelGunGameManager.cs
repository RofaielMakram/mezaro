using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PixelGunGameManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject [] playerPrefab;

    [SerializeField] int numCharacter;


    public static PixelGunGameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            instance = this;
        }
    }
    void Start()
    {
        if (PhotonNetwork.IsConnected) 
        {
            if (playerPrefab != null) 
            {
                int randompoint = Random.Range(-20, 20);
                PhotonNetwork.Instantiate(playerPrefab[numCharacter].name, new Vector3(randompoint, 0, randompoint), Quaternion.identity);
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName+ " joined to "+PhotonNetwork.CurrentRoom.Name+ " "+PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("GameLuncherScene");
    }

    public void LeaveRoom() 
    {
        PhotonNetwork.LeaveRoom();
    }

    public void select1()
    {
        numCharacter = 0;
    }
    public void select2()
    {
        numCharacter = 1;
    }
    public void select3()
    {
        numCharacter = 2;
    }

}
