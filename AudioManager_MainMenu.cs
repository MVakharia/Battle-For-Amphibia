using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_MainMenu : MonoBehaviour
{
    [SerializeField]
    private bool enableMusic;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip bgm;

    // Start is called before the first frame update
    void Start()
    {
        if (enableMusic)
        {
            _audioSource.PlayOneShot(bgm);
        }
    }
}