using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRespawn : MonoBehaviour
{

    //public Transform target;
    //public float t;

    public GameObject activeGameObject;
    public GameObject disactiveGameObject;

    /*[SerializeField] private Transform Arrow;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        Arrow.transform.position = respawnPoint.transform.position;
    }
    */
    void Start()
    {

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
