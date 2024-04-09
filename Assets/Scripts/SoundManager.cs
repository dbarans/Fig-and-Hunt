using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip buttonClickSound;
    public AudioClip gunshotSound;
    public AudioClip reloadSound;
    public AudioClip cashRegisterSound;
    public AudioClip backgroundMusic;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = backgroundMusic;
       
    }

    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void PlayGunshotSound()
    {
        audioSource.PlayOneShot(gunshotSound);
    }

    public void PlayReloadSound()
    {
        audioSource.PlayOneShot(reloadSound);
    }

    public void PlayCashRegisterSound()
    {
        audioSource.PlayOneShot(cashRegisterSound);
    }
}