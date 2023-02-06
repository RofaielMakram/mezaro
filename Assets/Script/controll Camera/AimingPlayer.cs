using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingPlayer : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    /// <summary> 
    [SerializeField]
    float mouseSensetivity=120f;
    [SerializeField]
    float mouseY;
    [SerializeField]
    float xRotation = 0f;
    /// </summary>
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        animator.SetFloat("Aiming", xRotation);
    }
}
