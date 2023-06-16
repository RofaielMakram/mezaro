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
    [SerializeField]
    PersonalWarriorType numTypeWarrior;
    private void Start()
    {
        inventory = Inventory.instance;

        int EquipnumSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;// know lenth (num Equipment  Slot)

        currentEquipment = new Equipment[EquipnumSlots];
        currentMeshes = new SkinnedMeshRenderer[EquipnumSlots];
        print(" Current Equip num Slot: " + EquipnumSlots);
        
        //Control Clothes
        Player = GameObject.FindGameObjectWithTag("Player");

        TopDefultCloth = Player.GetComponent<ArcherController>().pant;
        BottomDefultCloth = Player.GetComponent<ArcherController>().bra;

        //Use type my Warrior
        numTypeWarrior = Player.GetComponent<WarriorIdentity>().personalWarriorType;
        
    }


    int EquipSlotIndex;
    SkinnedMeshRenderer newMesh;

    public void Equip(Equipment newItem)
    {
        PersonalWarriorType WrriorSlotIndex = newItem.warriorSlot;// Warrior type for that equip like(Warrior Sword, Archer, Wizard)
        if (WrriorSlotIndex != numTypeWarrior)
            return;

        EquipSlotIndex = (int)newItem.equipSlot; // (دة رقم الدرع في الاربع خانات للبس اللاعب مثال (خانة السلاح , خانة الدرع, خانة الدرع العلوي 
       
        //   Test
        if (EquipSlotIndex == 2)
             TopDefultCloth.enabled = false;
           
        else if (EquipSlotIndex == 1)
             BottomDefultCloth.enabled = false;

        // Sent Current List Skills Weapon 
        if (newItem.skills != null)
            Player.GetComponent<ArcherShooting>().currentBowSkills = newItem.skills;
        ///////////////////////////////////////

        newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);


        Equipment oldItem = null;

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);//بشغل الميسود لو مش موجودة
        }


        if (currentEquipment[EquipSlotIndex] == null)
        {
            currentEquipment[EquipSlotIndex] = newItem;

            newMesh.transform.parent = targetMesh.transform;
            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
            currentMeshes[EquipSlotIndex] = newMesh;


        }
          else
          {
              oldItem = currentEquipment[EquipSlotIndex];
              inventory.Add(oldItem);  //بيضيف الاداة اللي هيتبدل بيها الجديدة للحقيبة تاني

              currentEquipment[EquipSlotIndex] = null; // CurrentEquipment هنشيل الاداة القديمة من ال

              Destroy(currentMeshes[EquipSlotIndex].gameObject); // هنا بقي هنمسح الاداة القديمة اللي لابسها اللاعب خالص

              currentEquipment[EquipSlotIndex] = newItem; // currentEquipment هنا هنضيف الاداة الجديدة في ليستة 
              currentMeshes[EquipSlotIndex] = newMesh; // currentMeshes هنا هنضيف الاداة الجديدة في ليستة

              // هنا بضبط new mesh equipment on player and riging 
              newMesh.transform.parent = targetMesh.transform;
              newMesh.bones = targetMesh.bones;
              newMesh.rootBone = targetMesh.rootBone;
          }
        newItem.RemoveFromInventory();
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
            if (EquipSlotIndex == 2)
                TopDefultCloth.enabled = true;

            else if (EquipSlotIndex == 1)
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


