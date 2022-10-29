using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broductSlot : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] Item item;
    void Start()
    {
        
    }
    public void UseProduct() 
    {
        bool wasPickedUp = Inventory.instance.Add(item); //Add to inventory
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
