using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SettingsController : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider soundVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] TMP_Text sensitivityText;
    [SerializeField] TMP_Text masterVolumeText;
    [SerializeField] TMP_Text soundVolumeText;
    [SerializeField] TMP_Text musicVolumeText;
    [SerializeField] MusicLoop musicLoop;

    void Awake()
    {
        sensitivitySlider.value = gameSettings.sensitivity;
        masterVolumeSlider.value = gameSettings.masterVolume;
        soundVolumeSlider.value = gameSettings.soundVolume;
        musicVolumeSlider.value = gameSettings.musicVolume;
    }

    void Update()
    {
        sensitivityText.text = sensitivitySlider.value.ToString();
        gameSettings.sensitivity = sensitivitySlider.value;

        masterVolumeText.text = masterVolumeSlider.value.ToString();
        gameSettings.masterVolume = masterVolumeSlider.value;

        soundVolumeText.text = soundVolumeSlider.value.ToString();
        gameSettings.soundVolume = soundVolumeSlider.value;

        musicVolumeText.text = musicVolumeSlider.value.ToString();
        gameSettings.musicVolume = musicVolumeSlider.value;

        musicLoop.UpdateVolume();
    }
}