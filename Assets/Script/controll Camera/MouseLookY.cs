using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookY : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float mouseSensetivity;
    [SerializeField]
    float xRotation = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -10f, 27f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
