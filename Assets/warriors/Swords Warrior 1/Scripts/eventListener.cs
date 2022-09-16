using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventListener : MonoBehaviour
{
    [SerializeField]
    managerAttack _MngrAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void AnimEventStart()
    {
        _MngrAttack.CheckAttackPhase1();
       
    }
    public void AnimEventEnd()
    {
        _MngrAttack.CheckAttackPhase2();
       
        
    }

    public void damageEvent() 
    {
        _MngrAttack.AttackDamage();
    }
    public void EnddamageEvent()
    {
        _MngrAttack.EndAttackDamage();
    }
}
