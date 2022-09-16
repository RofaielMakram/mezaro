using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;

    public override void Use()
    {
        base.Use();
        // equip the item
        EquipmentManager.instance.Equip(this);
        // remove from inventory
        RemoveFromInventory();
    }
}
public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
