using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanShop : Interactaple
{
    [SerializeField]GameObject shopWindow;
    public override void Interact()
    {
        base.Interact();


        Reaction();
    }
    void Reaction() 
    {
        shopWindow.SetActive(true);
    }
}
