using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerView : MonoBehaviour
{
    PhotonView PV;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private MonoBehaviour[] scriptsPlayer;

    // Start is called before the first frame 
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            PV = GetComponent<PhotonView>();
            Intialize();
        }
        else return;
       
    }

    void Intialize()
    {
        if (PV.IsMine)
        {
            playerCamera.SetActive(true);
            foreach (MonoBehaviour item in scriptsPlayer)
            {
                item.enabled = true;
            }
        }
        else
        {
            playerCamera.SetActive(false);
            foreach (MonoBehaviour item in scriptsPlayer)
            {
                item.enabled = false;
            }
        }
    }
    
}
