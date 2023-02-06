using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    [SerializeField]
    Transform cameTarget;
    [SerializeField]
    Transform AimTarget;

    public bool aiming;

    [SerializeField]
    float Positionlerb;
    [SerializeField]
    float Rotationlerb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        defultCamera();
        AimCamera();

    }

    public void defultCamera() 
    {
        if (aiming == false) 
        {
            transform.position = Vector3.Lerp(transform.position, cameTarget.position, Positionlerb);
            transform.rotation = Quaternion.Lerp(transform.rotation, cameTarget.rotation, Rotationlerb);
        }
       
    }

    public void AimCamera()
    {
        if (aiming==true)
        {
            transform.position = Vector3.Lerp(transform.position, AimTarget.position, Positionlerb);
            transform.rotation = Quaternion.Lerp(transform.rotation, AimTarget.rotation, Rotationlerb);
        }
    }
}
