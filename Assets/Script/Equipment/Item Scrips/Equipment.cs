using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public PersonalWarriorType warriorSlot;

    public SkinnedMeshRenderer mesh;

    public override void Use()
    {
        base.Use();
        // equip the item
        EquipmentManager.instance.Equip(this);
        // remove from inventory
       // RemoveFromInventory();
    }
}
//public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
public enum EquipmentSlot { Head, TopArmor, BottomArmor, Weapon, Shield, boot}// (0,*2*,*1*,3,4)

