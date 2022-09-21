using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem(Item newItem) 
    {
        item = newItem;

        icon.sprite = item.icon; // item هنا بياخد صورة الايتم اللي بتظهر في الحقيبة من 
        icon.enabled = true; // وبعد مخد الصورة من هناك يروح مفعل الصورة لان 

        removeButton.interactable = true;

    }

    public void ClearSlot() 
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

    }

    public void OnRemoveButton() // RemoveButton ui
    {
        Inventory.instance.Remove(item); // زرار حذف الاداة من الحقيبة (delet list items from inventory )
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        print("ok Delet");
    }
        
    public void UseItem() // item button ui
    {
        item.Use();
    }
}
