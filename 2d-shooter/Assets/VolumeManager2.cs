using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class VolumeManager2 : MonoBehaviour
{
    [SerializeField] private Slider gameVolumeSlider = null;
    [SerializeField] private TMP_Text gameVolumeTextValue = null;

    public void VolumeSlider(float volume)
    {
        gameVolumeTextValue.text = volume.ToString("0.0");
    }
}
