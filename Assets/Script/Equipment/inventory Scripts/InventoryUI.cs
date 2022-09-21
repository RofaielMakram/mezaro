using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    public GameObject inventoryUI;
    Inventory inventory; // الغرض منها هنا اننا نجيب الرقم اللي تقدر تستوعبه الحقيبة الخاصة باللاعب

    [SerializeField]InventorySlot[] slots;// inventorySlot ديه مصفوفة بتتجمع فيها كل الاوبجيكتات اللي فيها 

    void Start()
    {
        inventory = Inventory.instance;// singleton بيعرفه بأستخدام ال 
        inventory.onItemChangedCallback += UbdateUI; // UbdateUiكل مهيحصل تغيير في (الانفينتوري) هيستدعي    

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); // inventorySlot  بيحتوي علي child هنا بيتم معرفة كام
    }

    void Update()
    {
        // زرار لفتح قائمة الحقيبة   

        if (Input.GetButtonDown("Inventory")) 
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf); 
        }    
    }

    void UbdateUI() 
    {
        //print("inventory(1) : "+inventory.items.Count);
        for (int i=0; i < slots.Length; i++) // (1)دة رقم الخانات الفارغة في مخزون اللاعب
        {
          
            if (i < inventory.items.Count)  // دة عددالخانات المشغولة في المخزون
            {
               
                slots[i].AddItem(inventory.items[i]); 
            }else 
            {
                print("ok Delet");
                slots[i].ClearSlot();// (لحد ميوصل للعدد اللي متخزن في (كومنت رقم(1
            }
        }
        Debug.Log("Updating UI"); // امر طباعة بيأكد انا تم تم اضافة جميع خانات المخزون
    }
}
