using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : MonoBehaviour
{

    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
            
           
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
}
