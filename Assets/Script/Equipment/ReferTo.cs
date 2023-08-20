using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferTo : MonoBehaviour
{
    public Interactaple focus;

    [SerializeField]
    Camera fpsCamera;

    void Start()
    {
        //fpsCamera = Camera.main;
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = fpsCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;


            if (Physics.Raycast(ray, out _hit, 100))
            {      
                    RemoveFouse();
            }
        }

        if (Input.GetMouseButtonDown(1)) 
        {
           
            Ray ray = fpsCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit,100)) 
            {
                Interactaple interactaple = hit.collider.GetComponent<Interactaple>();
                if (interactaple != null)
                {
                    Setfocus(interactaple);
                }
                else {
                    Debug.Log("wwwww");
                }
            }
        }

    }

    void Setfocus(Interactaple newFouse) 
    {
        if (newFouse != focus) 
        {
            if (focus != null) 
            {
                focus.OnDefocused();
            }
           
            focus = newFouse;
        }
        
        newFouse.OnFocused(transform);
    }

    void RemoveFouse() 
    {
        if (focus != null) 
        {
            focus.OnDefocused();
        }
        
        focus = null;
    }
}


