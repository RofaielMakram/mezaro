using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;

public class managerAttack : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    private int CountAttackClick;

    [SerializeField]
    private Collider m_Collider;

   
    // Start is called before the first frame update
    void Start()
    {
        CountAttackClick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        BtnAttack();

    }

    private void BtnAttack() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            CountAttackClick++;
            if (CountAttackClick == 1)
            {
                animator.SetInteger("intAttackPhase", 1);
            }
        }
    }

    #region CheckAttackPhase1
    public void CheckAttackPhase1()
    {
        if (animator.GetCurrentAnimatorClipInfoCount(1).Equals(0))
        {
            Debug.Log("attack 1 start");
  
            playerController.runSpeed = 0; 
            playerController.SpeedRotate = 0;
        }
        else if (animator.GetCurrentAnimatorClipInfoCount(1).Equals(1))
        {
            Debug.Log("attack 2 start");
            playerController.runSpeed = 0;
            playerController.SpeedRotate = 0;
            transform.DOMove(transform.position + transform.forward*2.5f,0.8f);
        }
        else if (animator.GetCurrentAnimatorClipInfoCount(1).Equals(2))
        {
            Debug.Log("attack 3 start");
            playerController.runSpeed = 0;
            playerController.SpeedRotate = 0;
            transform.DOMove(transform.position + transform.forward * 0.5f, 0.5f);
            transform.DOMove(transform.position + transform.forward * 1.7f, 0.8f);
        }
    }
    #endregion

    #region CheckAttackPhase2
    public void CheckAttackPhase2() 
    {

        if (animator.GetCurrentAnimatorStateInfo(1).IsName("attack1"))
        {
            playerController.runSpeed = 6;
            playerController.SpeedRotate = 4;
            Debug.Log("attack 1 end");
            if (CountAttackClick > 1)
            {
                animator.SetInteger("intAttackPhase", 2);
            }
            else 
            {
                ResetAttackPhase();
            }
        }
        else if(animator.GetCurrentAnimatorStateInfo(1).IsName("attack2"))
        {
            Debug.Log("attack 2 end");
            playerController.runSpeed = 6;
            playerController.SpeedRotate = 4;
            
            if (CountAttackClick > 2)
            {
                animator.SetInteger("intAttackPhase", 3);
            }
            else
            {
                ResetAttackPhase();
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(1).IsName("attack3"))
        {
            Debug.Log("attack 3");
            playerController.runSpeed = 6;
            playerController.SpeedRotate = 4;
            if (CountAttackClick >= 3) 
            {
                ResetAttackPhase();
            }
        }
    }
    #endregion

    public void AttackDamage() 
    {
       // m_Collider = GetComponent<Collider>();
        m_Collider.enabled = true;
        Debug.Log("START ATTACK");

    }
    public void EndAttackDamage()
    {
        //m_Collider = GetComponent<Collider>();
        m_Collider.enabled = false;
        Debug.Log("END ATTACK"); 
    }

    private void ResetAttackPhase() 
    {
        CountAttackClick = 0;
        animator.SetInteger("intAttackPhase", 0);
    }
}
