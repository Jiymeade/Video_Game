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
    public AudioSource musicSource, sfxSource;
    public AudioClip musicClip, sfxClip;

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
        Debug.Log($"{slider.name} value: {slider.value}");
        if (slider.name == "MasterVolume")
        {
            audioMixer.SetFloat("MasterVolume", slider.value);
        }
        else if (slider.name == "MusicVolume")
        {
            audioMixer.SetFloat("MusicVolume", slider.value);
            musicSource.PlayOneShot(musicClip);
        }
        else if (slider.name == "SFXVolume")
        {
            audioMixer.SetFloat("SFXVolume", slider.value);
            sfxSource.PlayOneShot(sfxClip);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        masterVolume.onValueChanged.AddListener(delegate {PlayTestSound(masterVolume);});
        musicVolume.onValueChanged.AddListener(delegate {PlayTestSound(musicVolume);});
        sfxVolume.onValueChanged.AddListener(delegate {PlayTestSound(sfxVolume);});
    }
}
