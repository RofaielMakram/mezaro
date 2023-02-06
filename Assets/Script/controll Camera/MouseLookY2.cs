using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookY2 : MonoBehaviour
{
    [SerializeField]
    float mouseSensetivity;
    [SerializeField]
    float mouseY;
    [SerializeField]
    float xRotation=0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -56f, 19f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
