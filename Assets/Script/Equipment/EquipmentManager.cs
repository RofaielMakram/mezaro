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
    public SkinnedMeshRenderer targetMesh;
    Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;
    private void Start()
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
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
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItems.mesh);
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[SlotIndex] = newMesh;
    }

    public void Unequip(int slotIndex) 
    {
        if (currentEquipment[slotIndex] != null) 
        {
            Destroy(currentMeshes[slotIndex].gameObject);
        }
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
