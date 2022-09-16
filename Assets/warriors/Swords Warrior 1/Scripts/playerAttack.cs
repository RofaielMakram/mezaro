using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    // timer Attack
    [SerializeField] float currentTime;
    //[SerializeField]float maxTime;
    [SerializeField] float MaxTime;


    //Animation
    [SerializeField] Animator animator;


    PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (currentTime < MaxTime)
        {
            animator.SetBool("SwordAttack", false); // Motion attack(1) (OFF)
            currentTime += Time.deltaTime;  // Timer

           // playerController.maxRunSpeed = 0f;
           // playerController.maxSpeedRotate = 10f;
        }
        else if (currentTime > MaxTime)
        {
            if (Input.GetKey(KeyCode.K)) // Input (k)
            {
                currentTime = 0f; //Timer

                if ("SwordAttack" != null)
                {
                    animator.SetBool("SwordAttack", true);// Motion attack (ON)
                }
            }
            //playerController.maxRunSpeed = 6f;
            //playerController.maxSpeedRotate = 6f;
        }



    }


}
