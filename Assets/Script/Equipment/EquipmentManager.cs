using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using ExitGames.Client.Photon;

public class EquipmentManager : MonoBehaviourPunCallbacks
{
    #region Singletoon
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    PlayerFindMesh playerFindMesh;
    public GameObject Player;
    public SkinnedMeshRenderer targetMesh;   // دة بيشاور اللاعب
    public Equipment[] currentEquipment;


    [SerializeField] SkinnedMeshRenderer[] currentMeshes;



    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    [SerializeField]
    SkinnedMeshRenderer TopDefultCloth, BottomDefultCloth;
    private void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        print(numSlots);
        //Control Clothes
        Player = GameObject.FindGameObjectWithTag("Player");
        TopDefultCloth = Player.GetComponent<ArcherController>().pant;
        BottomDefultCloth = Player.GetComponent<ArcherController>().bra;
    }


    int SlotIndex;
    SkinnedMeshRenderer newMesh;

    
    public void Equip(Equipment newItem)
    {
        SlotIndex = (int)newItem.equipSlot; // (دة رقم الدرع في الاربع خانات للبس اللاعب مثال (خانة السلاح , خانة الدرع, خانة الدرع العلوي 
        //   Test
        if (SlotIndex == 2)
             TopDefultCloth.enabled = false;
           
        else if (SlotIndex == 1)
             BottomDefultCloth.enabled = false;
            ///////////////////////////////////////

            newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);


        Equipment oldItem = null;

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);//بشغل الميسود لو مش موجودة
        }


        if (currentEquipment[SlotIndex] == null)
        {
            currentEquipment[SlotIndex] = newItem;

            newMesh.transform.parent = targetMesh.transform;
            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
            currentMeshes[SlotIndex] = newMesh;


        }
          else
          {
              oldItem = currentEquipment[SlotIndex];
              inventory.Add(oldItem);  //بيضيف الاداة اللي هيتبدل بيها الجديدة للحقيبة تاني

              currentEquipment[SlotIndex] = null; // CurrentEquipment هنشيل الاداة القديمة من ال

              Destroy(currentMeshes[SlotIndex].gameObject); // هنا بقي هنمسح الاداة القديمة اللي لابسها اللاعب خالص

              currentEquipment[SlotIndex] = newItem; // currentEquipment هنا هنضيف الاداة الجديدة في ليستة 
              currentMeshes[SlotIndex] = newMesh; // currentMeshes هنا هنضيف الاداة الجديدة في ليستة

              // هنا بضبط new mesh equipment on player and riging 
              newMesh.transform.parent = targetMesh.transform;
              newMesh.bones = targetMesh.bones;
              newMesh.rootBone = targetMesh.rootBone;
          }
    }
    SkinnedMeshRenderer i(SkinnedMeshRenderer newMeshs)
    {

        return newMeshs;
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
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
            if (SlotIndex == 2)
                TopDefultCloth.enabled = true;

            else if (SlotIndex == 1)
                BottomDefultCloth.enabled = true;
        }
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.U)) //  هيشيل كل الدروع اللي لبستها
        {
            UnequipAll();
        }
       
        if (Player != null)
        {
            targetMesh = Player.GetComponentInChildren<SkinnedMeshRenderer>();
        }
    }
}


