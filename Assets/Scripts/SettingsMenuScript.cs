using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    public AudioSource AudioSourceMusic;
    public AudioSource AudioSourceSoundEffects;

    public Slider volumeMusicSlide;
    public Slider volumeSoundEffectsSlide;

    private float MusicVolume = 1f;
    private float SoundEffectsVolume = 1f;

    private void Start()
    {
        AudioSourceMusic.Play();
        AudioSourceSoundEffects.Play();

        MusicVolume = PlayerPrefs.GetFloat("MusicVolume:");
        SoundEffectsVolume = PlayerPrefs.GetFloat("SoundEffectsVolume:");

        AudioSourceMusic.volume = MusicVolume;
        volumeMusicSlide.value = MusicVolume;

        AudioSourceSoundEffects.volume = SoundEffectsVolume;
        volumeSoundEffectsSlide.value = SoundEffectsVolume;
    }


    private void Update()
    {
        AudioSourceMusic.volume = MusicVolume;
        AudioSourceSoundEffects.volume = SoundEffectsVolume;

        PlayerPrefs.SetFloat("MusicVolume:", MusicVolume);
        PlayerPrefs.GetFloat("SoundEffectsVolume:", SoundEffectsVolume);
    }

    public void Volumeupdater(float volume)
    {
        MusicVolume = volume;
        SoundEffectsVolume = volume;
    }

    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("MusicVolume:");
        AudioSourceMusic.volume = 1;
        volumeMusicSlide.value = 1;

        PlayerPrefs.DeleteKey("SoundEffectsVolume:");
        AudioSourceSoundEffects.volume = 1;
        volumeSoundEffectsSlide.value = 1;
    }
}
