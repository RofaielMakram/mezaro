using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ItemPickup : Interactaple
{
    private PhotonView pv;
    public Item item;
    public override void Interact()
    {
        base.Interact();


        PickUp();
    }


    public void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item); //Add to inventory

        if (wasPickedUp)
        {
            if (PhotonNetwork.IsConnected)
            {
                pv = GetComponent<PhotonView>();
                pv.RPC("die", RpcTarget.AllBuffered);
                Debug.Log("PV Is Mine");
            }
            else 
            {
                Debug.Log("Destroy item in ground");
                Destroy(gameObject);
            }
        }
    }

    [PunRPC]
    void die()
    {
        Destroy(gameObject);
    }
}
