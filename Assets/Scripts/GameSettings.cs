using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Settings", menuName = "Custom/Game Settings")]
public class GameSettings : ScriptableObject
{
    const string SENSITIVITY_KEY = "Sensitivity";
    const string MASTER_VOLUME_KEY = "MasterVolume";
    const string MUSIC_VOLUME_KEY = "MusicVolume";
    const string SOUND_VOLUME_KEY = "SoundVolume";

    public float sensitivity;
    public float masterVolume;
    public float musicVolume;
    public float soundVolume;

    public float RangedMasterVolume => masterVolume / 100f;
    public float RangedMusicVolume => musicVolume / 100f;
    public float RangedSoundVolume => soundVolume / 100f;

    public float ScaledRangedMusicVolume => RangedMusicVolume * RangedMasterVolume;
    public float ScaledRangedSoundVolume => RangedSoundVolume * RangedMasterVolume;

    public void Save()
    {
        PlayerPrefs.SetFloat(SENSITIVITY_KEY, sensitivity);
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, masterVolume);
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, musicVolume);
        PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, soundVolume);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        PlayerPrefs.GetFloat(SENSITIVITY_KEY);
        PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
        PlayerPrefs.GetFloat(SOUND_VOLUME_KEY);
    }
}
