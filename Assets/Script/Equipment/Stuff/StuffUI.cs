using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffUI : MonoBehaviour
{
   [SerializeField] GameObject stuff;
    void Update()
    {
        if (Input.GetButtonDown("Stuff"))
        {
            stuff.SetActive(!stuff.activeSelf);
        }
    }
}
