using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //audio source, seperates bg music from sfx
    [Header("------- Audio Source -------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    //list of audio clips
    [Header("------- Audio Clips -------")]
    public AudioClip background;
    public AudioClip walk;
    public AudioClip playerAttack;
    public AudioClip playerDeath;
    public AudioClip hitEnemy;
    public AudioClip hitPlayer;
    public AudioClip enemyAttack;
    public AudioClip enemyDeath;
    public AudioClip itemPickup;
    public AudioClip levelClear;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
