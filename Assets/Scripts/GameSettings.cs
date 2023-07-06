using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Settings", menuName = "Custom/Game Settings")]
public class GameSettings : ScriptableObject
{
    public float sensitivity;
    public float masterVolume;
    public float musicVolume;
    public float soundVolume;

    public float RangedMasterVolume => masterVolume / 100f;
    public float RangedMusicVolume => musicVolume / 100f;
    public float RangedSoundVolume => soundVolume / 100f;

    public float ScaledRangedMusicVolume => RangedMusicVolume * RangedMasterVolume;
    public float ScaledRangedSoundVolume => RangedSoundVolume * RangedMasterVolume;
}
