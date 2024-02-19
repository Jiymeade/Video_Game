using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsManager : MonoBehaviour
{

    public Slider masterVolume, musicVolume, sfxVolume;
    public AudioMixer audioMixer;

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", masterVolume.value);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", musicVolume.value);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", sfxVolume.value);
    }

    public void PlayTestSound(Slider slider)
    {
        // Play a test sound
        Debug.Log($"{slider.name} value: {slider.value}");
    }

    // Start is called before the first frame update
    void Start()
    {
        masterVolume.onValueChanged.AddListener(delegate {PlayTestSound(masterVolume);});
        musicVolume.onValueChanged.AddListener(delegate {PlayTestSound(musicVolume);});
        sfxVolume.onValueChanged.AddListener(delegate {PlayTestSound(sfxVolume);});
    }
}
