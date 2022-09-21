using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // (ItemPickup)هنا بقي استخدمنا طريقة الديزاين باترن دية عشان نعمل اتصال مبين الكلاس بتاعنا و 
    #region Singleton 
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }
        instance = this;
    }

    #endregion

    //do not understand
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>(); // ده مخزون اللاعب في الجيم (1

    public int Space = 10;

    // EquipmentManager.Unequip (add old item to inventory )
    public bool Add(Item item) 
    {
        if (!item.isDefaultItem) // (2  if (isDefaultItem)=true   
        {
            if (items.Count >= Space) 
            {
                Debug.Log("Not enough room"); // (4 (isDefaultItem)=false هنا بقي لو الشنطة اتملت يبقي خلي ال 

                return false;
            }

            items.Add(item); // (3 لو الشرط اتنفذ ضيف الايتم ديه في المخزون
            //do not understand
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }


        return true;
    }

    public void Remove(Item item) // inventorySlot.OnRemoveButton UI
    {
        items.Remove(item);
        //do not understand
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
