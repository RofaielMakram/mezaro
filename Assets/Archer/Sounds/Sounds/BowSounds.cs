using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowSounds : MonoBehaviour
{
     public AudioSource source;

    public AudioClip arrowaudio;
    public AudioClip stringaudio;
    public AudioClip fireaudio;


    public void arrowsound()
    {
        source.clip = arrowaudio;
        source.Play();
    }

    public void stringsound()
    {
        source.clip = stringaudio;
        source.Play();
    }

    public void firesound()
    {
        source.clip = fireaudio;
        source.Play();
    }
}
