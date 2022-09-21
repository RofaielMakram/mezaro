﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffUI : MonoBehaviour
{

   [SerializeField] GameObject stuff;

    public Transform EquipParent;
    [SerializeField] InventorySlot[] slots;

    private void Start()
    {
       // slots = EquipParent.GetComponentInChildren<InventorySlot>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Stuff"))
        {
            stuff.SetActive(!stuff.activeSelf);
        }
    }
}
