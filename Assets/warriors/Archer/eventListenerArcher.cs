﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventListenerArcher : MonoBehaviour
{
     [SerializeField]
    ArcherShooting _archershoting;

     [SerializeField]
    BowSounds _BowSound;

     [SerializeField]
    FootStepsSound _FootSound;

    [SerializeField]
    TakingDamage _damage;

    [SerializeField]
    cameraControl _cameraControl;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    #region ArcherShootingScript
    public void setAim() 
    {
        _cameraControl.aiming = true;
    }
    public void ShotingAnim()
    {
        _archershoting.EventAnim();
    }

    public void DrawArrow()
    {
        _archershoting.ArrowEvent();
    }

    public void DisActiveArrow()
    {
        //_archershoting.DisActiveArrowEvent();
    }

    #endregion

    #region  BowSoundsScript

    public void arrowsoundEvent()
    {
        _BowSound.arrowsound();
    }

    public void stringsoundEvent()
    {
        _BowSound.stringsound();
    }

    public void firesoundEvent()
    {
        _BowSound.firesound();
    }

    #endregion

    #region  FootStepsSoundScript

    public void footsoundEvent()
    {
        _FootSound.footsound();
    }

    #endregion

    #region  TakingDamageScript

    public void DieEvent()
    {
        _damage.Die();
    }

    #endregion



}
