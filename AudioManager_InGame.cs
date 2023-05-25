using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_InGame : AudioManager
{
    [SerializeField] AudioClip clip_GameOver;

    public void PlayBGM_GameOver ()
    {
        _audioSource_BGM.clip = clip_GameOver;
        _audioSource_BGM.Play();
    }

    public void StopBGM ()
    {
        _audioSource_BGM.Stop();
    }

    private void Start()
    {
        PlayMusic();
    }
}