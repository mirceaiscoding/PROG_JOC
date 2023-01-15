using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class VolumeManager : MonoBehaviour
{
    // Singleton design pattern :)
    public static VolumeManager instance = null;

    [SerializeField] private Slider gameVolumeSlider = null;
    [SerializeField] private TMP_Text gameVolumeTextValue = null;

    [SerializeField] private Slider musicVolumeSlider = null;
    [SerializeField] private TMP_Text musicVolumeTextValue = null;

    [SerializeField] private float defaultGameVolume = 1.0f;
    [SerializeField] private float defaultMusicVolume = 1.0f;

    [SerializeField] private GameObject backgroundMusic;

    [SerializeField] private GameObject[] objectsWithAudio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        float gameVolume = PlayerPrefs.GetFloat("gameVolume", 1.0f);
        gameVolumeSlider.value = gameVolume;
        gameVolumeTextValue.text = gameVolume.ToString("0.0");
        ChangeVolumeForAllScenes(gameVolume);

        float musicVolume = PlayerPrefs.GetFloat("musicVolume", 1.0f);
        musicVolumeSlider.value = musicVolume;
        musicVolumeTextValue.text = musicVolume.ToString("0.0");
        backgroundMusic.GetComponent<AudioSource>().volume = musicVolume;
    }

    public void ChangeVolumeForAllScenes(float volume)
    {
        ChangeVolumeForAllScenes(volume);
        PlayerPrefs.SetFloat("gameVolume", volume);
        gameVolumeTextValue.text = volume.ToString("0.0");
    }

    public void GameVolumeSlider(float volume)
    {
        foreach (GameObject obj in objectsWithAudio)
        {
            AudioSource[] audioSources = obj.GetComponents<AudioSource>();
            foreach (AudioSource audio in audioSources)
            {
                audio.volume = volume;
            }
        }
    }

    public void MusicVolumeSlider(float volume)
    {
        backgroundMusic.GetComponent<AudioSource>().volume = volume;
        musicVolumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("musicVolume", backgroundMusic.GetComponent<AudioSource>().volume);
    }

    public void ResetButton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultMusicVolume;
            musicVolumeSlider.value = defaultMusicVolume;
            gameVolumeTextValue.text = defaultMusicVolume.ToString("0.0");
            VolumeApply();
        }
    }
}
