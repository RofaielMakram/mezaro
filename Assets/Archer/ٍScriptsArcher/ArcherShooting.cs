using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ArcherShooting : MonoBehaviour
{
    [SerializeField]
    Camera fbsCamera;



    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public void EventAnim()
    {


            //Reset fireTimer
           


        RaycastHit _hit;
        Ray ray = fbsCamera.ViewportPointToRay(new Vector3(0.5f,0.5f));


        if (Physics.Raycast(ray,out _hit,100))
        {

            Debug.Log(_hit.collider.gameObject.name);

            if (_hit.collider.gameObject.CompareTag("Player")&&!_hit.collider.gameObject.GetComponent<PhotonView>().IsMine)
            {
                _hit.collider.gameObject.GetComponent<PhotonView>().RPC("TakeDamage",RpcTarget.AllBuffered,10f);
            }

                
        
        }
           
    }   
}
