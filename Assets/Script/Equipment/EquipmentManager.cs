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
    public SkinnedMeshRenderer targetMesh;   // دة بيشاور اللاعب
    [SerializeField]Equipment[] currentEquipment;

    //[SerializeField]SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;
    private void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
       // currentMeshes = new SkinnedMeshRenderer[numSlots];
    }

    public void Equip(Equipment newItems)
    {
        int SlotIndex = (int)newItems.equipSlot; // عدد انواع الدروع اللي بتتلبس مثال: الخوزة الدرع الحذاء....الخ

       

        Equipment oldItem = null;


        

        if (onEquipmentChanged != null) 
        {
            onEquipmentChanged.Invoke(newItems, oldItem);
        }

        currentEquipment[SlotIndex] = newItems;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItems.mesh);

        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        //currentMeshes[SlotIndex] = newMesh;
    }

    public Equipment Unequip(int slotIndex) 
    {
        if (currentEquipment[slotIndex] != null) 
        {
           // Destroy(currentMeshes[slotIndex].gameObject);


            // أضف العنصر في المخزون
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            // ازالة الدرع(الحاجة اللي انت لابسها) من المعدات
            currentEquipment[slotIndex] = null;

            // تمت إزالة المعدات لذلك نقوم بتشغيل رد الاتصال
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem); ;
            }
            return oldItem;
        }
        return null;
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
        if (Input.GetKeyDown(KeyCode.U)) //  هيشيل كل الدروع اللي لبستها
        {
            UnequipAll();
        }
            
    }
}
