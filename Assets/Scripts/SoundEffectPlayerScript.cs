using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectPlayerScript : MonoBehaviour
{
    private AudioSource audioSource;
    private float musicVolume = 1f;
    public Slider musicVolumeSlider;
    public GameObject ObjectMusic;
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("SoundEffects");
        audioSource = ObjectMusic.GetComponent<AudioSource>();

        musicVolumeSlider.value = musicVolume;
        musicVolume = PlayerPrefs.GetFloat("effects");
        audioSource.volume = musicVolume;
        musicVolumeSlider.value = musicVolume;
    }

    void Update()
    {
        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("effects", musicVolume);
    }

    public void UpdateEffectsVolume(float volume)
    {
        musicVolume = volume;
    }

    public void EffectsReset()
    {
        PlayerPrefs.DeleteKey("effects");
        audioSource.volume = 1;
        musicVolumeSlider.value = 1;
    }
}
