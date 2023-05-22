using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioManager : MonoBehaviour
{
    [SerializeField] protected bool enableMusic;
    [SerializeField] protected AudioSource _audioSource_BGM;
    
    protected void PlayMusic ()
    {
        if (enableMusic) _audioSource_BGM.Play();
    }
}