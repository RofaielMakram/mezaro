using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class TakingDamage : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Image healthBar;

    [SerializeField]
    private float health;
    public float startHealth = 100;

    [SerializeField]Animator animator;

    void Start()
    {
        health = startHealth;
        healthBar.fillAmount = health/startHealth;
    }


    void Update()
    {
        Damegechangecolor();
    }

    [PunRPC]
    public void TakeDamage(float _damage) 
    {
        health -= _damage;
        Debug.Log(health);
        healthBar.fillAmount = health / startHealth;
        if (health <= 0f) 
        {
            //Die
            ANIM();
        }
    }

    public void Die() 
    {
        if (photonView.IsMine) 
        {
            PixelGunGameManager.instance.LeaveRoom();
        }
    }

    void ANIM()
    {
        animator.SetBool("Die", true);
    }


    void Damegechangecolor()
    {
        if (health == 60)
        {
            healthBar.GetComponent<Image>().color = new Color32(255,159,0,255);
        }

        if (health <= 30)
        {
            healthBar.GetComponent<Image>().color = new Color32(255,0,0,255);
        }
    }

}
