using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// original اللي هيتنقله التحديث 
public class ArcherShooting : MonoBehaviour
{
    [SerializeField]
    Camera fbsCamera;
    [SerializeField]
    cameraControl _cameraControl;

    [SerializeField]
    Animator animator;

    public GameObject[] currentBowSkills;

    [SerializeField]
    GameObject instantiatePointArrow;



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
        RaycastHit _hit;
        Ray ray = fbsCamera.ViewportPointToRay(new Vector3(0.5f,0.5f));


        if (Physics.Raycast(ray,out _hit,100))
        {

            Debug.Log(_hit.collider.gameObject.name);

            if (PhotonNetwork.IsConnected)//!_hit.collider.gameObject.GetComponent<PhotonView>().IsMine &&
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
                //back to defult camera
                _cameraControl.aiming = false;
            }
            

        }
           
    }

    GameObject currentEffect;
    public void ArrowEvent()
    {
        if (currentBowSkills[0] != null)
        {

            currentEffect = Instantiate(currentBowSkills[0], instantiatePointArrow.transform.position, instantiatePointArrow.transform.rotation);

            currentEffect.transform.SetParent(instantiatePointArrow.transform);
        }

    }

    public void DisActiveArrowEvent()
    {
        if (currentEffect != null)
            Destroy(currentEffect);
    } 
}
