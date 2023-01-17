using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ArcherShooting : MonoBehaviour
{
    [SerializeField]
    Camera fbsCamera;

    [SerializeField]
    Animator animator;

    public GameObject activeGameObject;
    public GameObject disactiveGameObject;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // if point on any UI Windows make nothing
        if (EventSystem.current.IsPointerOverGameObject())
            return;
            
        //fire

        if(Input.GetButton("Fire1"))
        {
            Debug.Log("ok");
            animator.SetBool("fire", true);
        }
        else
        {
            animator.SetBool("fire", false);
        }
            
    }
    

    public void EventAnim()
    {


            //Reset fireTimer
           


        RaycastHit _hit;
        Ray ray = fbsCamera.ViewportPointToRay(new Vector3(0.5f,0.5f));


        if (Physics.Raycast(ray,out _hit,100))
        {

            Debug.Log(_hit.collider.gameObject.name);
            if (!_hit.collider.gameObject.GetComponent<PhotonView>().IsMine && PhotonNetwork.IsConnected)
            {
                if (_hit.collider.gameObject.CompareTag("Player"))
                {
                    _hit.collider.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.AllBuffered, 10f);
                }
            }
            else 
            {
                if (_hit.collider.gameObject.CompareTag("Player"))
                {
                    _hit.collider.gameObject.GetComponent<TakingDamage>().TakeDamage(10f);
                }
            }
            

                
        
        }
           
    }  

    public void ArrowEvent()
    {
        activeGameObject.SetActive(true);

    }

    public void DisActiveArrowEvent()
    {
        disactiveGameObject.SetActive(false);
    } 
}
