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
    public Equipment[] currentEquipment;

    [SerializeField]SkinnedMeshRenderer[] currentMeshes;

   

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public delegate void OnStuffChanged(); // test
    public OnStuffChanged onEquipChanged;//test

    Inventory inventory;


    private void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        print(numSlots);
    }

    public void Equip(Equipment newItems)
    {
        int SlotIndex = (int)newItems.equipSlot; // (دة رقم الدرع في الاربع خانات للبس اللاعب مثال (خانة السلاح , خانة الدرع, خانة الدرع العلوي 
        

        Equipment oldItem = null;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItems.mesh);

        if (onEquipmentChanged != null) 
        {
            onEquipmentChanged.Invoke(newItems, oldItem);//بشغل الميسود لو مش موجودة
        }
       

        if (currentEquipment[SlotIndex] == null)
        {
            currentEquipment[SlotIndex] = newItems;
            

            newMesh.transform.parent = targetMesh.transform;
            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
            currentMeshes[SlotIndex] = newMesh;
        }
        else 
        {
            oldItem = currentEquipment[SlotIndex];  
            inventory.Add(oldItem);  //بيضيف الاداة اللي هيتبدل بيها الجديدة للحقيسة تاني

            currentEquipment[SlotIndex] = null; // CurrentEquipment هنشيل الاداة القديمة من ال

            Destroy(currentMeshes[SlotIndex].gameObject); // هنا بقي هنمسح الاداة القديمة اللي لابسها اللاعب خالص

            currentEquipment[SlotIndex] = newItems; // currentEquipment هنا هنضيف الاداة الجديدة في ليستة 
            currentMeshes[SlotIndex] = newMesh; // currentMeshes هنا هنضيف الاداة الجديدة في ليستة

            // هنا بضبط new mesh equipment on player and riging 
            newMesh.transform.parent = targetMesh.transform;
            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
        }
        
    }

    public Equipment Unequip(int slotIndex) 
    {
        if (currentEquipment[slotIndex] != null) 
        {
            Destroy(currentMeshes[slotIndex].gameObject); // لم بدوس يو بيشيل كل التجهيزات اللي علي اللاعب 


            // أضف العنصر في المخزون
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            // ازالة الدرع(الحاجة اللي انت لابسها) من المعدات
            currentEquipment[slotIndex] = null;

            // تمت إزالة المعدات لذلك نقوم بتشغيل رد الاتصال
           

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
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
