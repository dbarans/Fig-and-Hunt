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
        audioSource.loop = true; // Ustawienie zapêtlenia muzyki t³a
        audioSource.clip = backgroundMusic; // Ustawienie muzyki t³a
        audioSource.Play(); // Odtworzenie muzyki t³a
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