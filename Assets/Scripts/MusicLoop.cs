using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    [SerializeField] Sound music;
    [SerializeField] GameSettings gameSettings;

    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        source.loop = true;
        source.clip = music.clip;
        source.pitch = music.pitch;
        source.volume = music.volume * gameSettings.ScaledRangedMusicVolume;

        source.Play();
    }

    public void UpdateVolume()
    {
        source.volume = music.volume * gameSettings.ScaledRangedMusicVolume;
    }
}
