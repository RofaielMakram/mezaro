using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class D : MonoBehaviour
{
    [SerializeField]
    int Damage =10;

    H h = new H();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            h = other.GetComponent<H>();
            h.health = h.health - Damage;
        }
    }
}
