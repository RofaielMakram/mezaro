using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StuffUI : MonoBehaviour
{

   [SerializeField] GameObject stuff;

    public Transform EquipParent;
    [SerializeField] InventorySlot[] slots;
    Inventory inventory;
   [SerializeField] EquipmentManager equipmentManager;

    private void Start()
    {
        slots = EquipParent.GetComponentsInChildren<InventorySlot>();
        //equipmentManager = EquipmentManager.instance;
        //equipmentManager.onEquipmentChanged();
    }
    void Update()
    {
        if (Input.GetButtonDown("Stuff"))
        {
            stuff.SetActive(!stuff.activeSelf);
        }

        UpdateUI();
    }

    void UpdateUI() 
    {
        for (int i = 0; i < equipmentManager.currentEquipment.Length; i++)
        {
            if (equipmentManager.currentEquipment[i] != null)
                slots[i].AddItem(equipmentManager.currentEquipment[i]);
        }
    }
}
