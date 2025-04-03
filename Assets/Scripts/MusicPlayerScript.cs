using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{
    private AudioSource audioSource;
    private float musicVolume = 1f;
    public Slider musicVolumeSlider;
    public GameObject ObjectMusic;
    void Awake()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        audioSource = ObjectMusic.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        audioSource.volume = musicVolume;
        musicVolumeSlider.value = musicVolume;
        MusicReset();
    }

    void Update()
    {
        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void UpdateMusicVolume(float volume)
    {
        musicVolume = volume;
    }

    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("MusicVolume");
        audioSource.volume = 1;
        musicVolumeSlider.value = 1;
    }

    public void MusicMute()
    {
        PlayerPrefs.DeleteKey("MusicVolume");
        audioSource.volume = 0;
        musicVolumeSlider.value = 0;
    }
}
