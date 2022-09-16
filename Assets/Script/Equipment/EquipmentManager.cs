using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singletoon
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;
    private void Start()
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItems)
    {
        int SlotIndex = (int)newItems.equipSlot;

        Equipment oldItem = null;


        if (currentEquipment[SlotIndex] != null) 
        {
            oldItem = currentEquipment[SlotIndex];

            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null) 
        {
            onEquipmentChanged.Invoke(newItems, oldItem);
        }

        currentEquipment[SlotIndex] = newItems;
    }

    public void Unequip(int slotIndex) 
    {
        if (currentEquipment[slotIndex] != null) 
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem); ;
            }
        }
        
    }

    public void UnequipAll() 
    {
        for (int i=0; i < currentEquipment.Length; i++) 
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) 
        {
            UnequipAll();
        }
            
    }
}
