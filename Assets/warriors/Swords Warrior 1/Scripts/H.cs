using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class H : MonoBehaviourPunCallbacks
{
    
    public int health=100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        die();
    }

    void die() 
    {
        if (health <= 0) 
        {
            if (photonView.IsMine)
            {
               // PixelGunGameManager.instance.LeaveRoom();
            }
        }
    }

    
}
