using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactaple : MonoBehaviour
{
    public float raduius = 3f;
    public bool isFocus = false;

    Transform player;

    private void Update()
    {
        if (isFocus) 
        {
            float distance = Vector3.Distance(player.position, transform.position);

            
            if (distance <= raduius) 
            {
                Debug.Log("INTERACT");
                Interact();
            }
        }
    }
    public void OnFocused(Transform playerTransform) 
    {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused() 
    {
        isFocus = false;
        player = null;
    }
    public virtual void Interact() 
    {
        Debug.Log("Intracting with" + transform.name);
    }

    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, raduius);
    }

}
