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

    Quaternion r = Quaternion.Euler(170f, 0f, 0f);


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
            animator.SetBool("fire", true);
        }
        else
        {
            animator.SetBool("fire", false);
        }
            
    }

    GameObject currentEffect;
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
            }
            // instantiete explosion
            if (currentBowSkills.Length > 0 && currentBowSkills[2] != null) {
                currentEffect = Instantiate(currentBowSkills[2], _hit.point, Quaternion.LookRotation(_hit.point-transform.position));
                Destroy(currentEffect, 1);
            }

        }

            if (currentBowSkills.Length > 0 && currentBowSkills[1] != null) {
                currentEffect = Instantiate(currentBowSkills[1], instantiatePointArrow.transform.position, Quaternion.Euler(170f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                Destroy(currentEffect, 1);
            }
            
            //back to defult camera
            _cameraControl.aiming = false;
           
    }

    
    public void ArrowEvent()
    {
        if (currentBowSkills.Length > 0 && currentBowSkills[0] != null)
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
