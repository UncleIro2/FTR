using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum SoundEnum
{
    fire = 0,
    klik = 1,
    correct = 2,
    storm = 3,
    start = 4, 
    earthquake = 5,
}

//SoundMananger.instance.PlaySound(SoundEnum.fire);

public class SoundMananger : MonoBehaviour
{
    public AudioClip[] soundLib;
    private List<AudioSource> audioSources = new List<AudioSource>();

    public static SoundMananger instance { get; private set;}

    private void Awake()
    {
        foreach (AudioClip clip in soundLib) {
            AudioSource audioSource = this.AddComponent<AudioSource>();
            audioSources.Add(audioSource);
            audioSource.clip = clip;
        }
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySound(SoundEnum soundEnum)
    {
        AudioSource audioSource = audioSources[(int)soundEnum];
        audioSource.Play();
    }

    public void StopAllSounds()
    {
        foreach(AudioSource source in instance.audioSources) {
            source.Stop();
        }
    }
}