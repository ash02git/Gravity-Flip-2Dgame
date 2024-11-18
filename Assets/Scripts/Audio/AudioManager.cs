using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance {  get { return instance; } }

    public SoundType[] soundtypeArray;
    public AudioSource sfx;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            sfx.PlayOneShot(clip);
        }
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(soundtypeArray, sitem => sitem.soundtype == sound);
        if (item != null)
        {
            return item.clip;
        }
        return null;
    }
}



[Serializable]
public class SoundType
{
    public AudioClip clip;
    public Sounds soundtype;
}


public enum Sounds
{
    Collectible,
    Spikehit,
    Death,
    Powerup,
    ButtonClick,
    GravityFlip
}

