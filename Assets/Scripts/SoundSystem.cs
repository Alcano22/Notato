using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem Instance { get; private set; }

    AudioSource source;

    void Awake()
    {
        Instance = this;

        source = GetComponent<AudioSource>();
    }

    public void PlaySound(Sound sound)
    {
        source.volume = sound.volume;
        source.pitch = sound.pitch;

        source.PlayOneShot(sound.clip);
    }
}

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public float volume = 1f;
    public float pitch = 1f;

    public void Play()
    {
        SoundSystem.Instance.PlaySound(this);
    }
}
