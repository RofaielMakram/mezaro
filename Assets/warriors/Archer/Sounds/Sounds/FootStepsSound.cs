using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsSound : MonoBehaviour
{
    public AudioSource source;

    public AudioClip footstep;

    public void footsound()
    {
        source.clip = footstep;
        source.Play();
    }
}
