using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider gameVolumeSlider = null;
    [SerializeField] private TMP_Text gameVolumeTextValue = null;

    [SerializeField] private Slider musicVolumeSlider = null;
    [SerializeField] private TMP_Text musicVolumeTextValue = null;

    public void GameVolumeSlider(float volume)
    {
        AudioListener.volume = volume;
        gameVolumeTextValue.text = volume.ToString("0.0");
    }

    public void GameVolumeApply()
    {
        PlayerPrefs.SetFloat("gameVolume", AudioListener.volume);
    }

    public void MusicVolumeSlider(float volume)
    {
        AudioListener.volume = volume;
        musicVolumeTextValue.text = volume.ToString("0.0");
    }

    public void MusicVolumeApply()
    {
        PlayerPrefs.SetFloat("musicVolume", AudioListener.volume);
    }
}
