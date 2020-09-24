using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;
    public GameObject musicVolObj;
    public Slider musicSlider;

    void Start()
    {
        musicVolObj = GameObject.Find("MusicVolObj");
        musicSlider = (Slider)GameObject.FindObjectsOfType(typeof(Slider))[0];

        musicSlider.value = musicVolObj.GetComponent<MusicVolObj>().musicVolValue;
        musicVolObj.GetComponent<MusicVolObj>().musicSlider = musicSlider;
        //selectedSongObject.GetComponent<SongObjectScript>().difficultyMultiplier = 1;
    }

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("volume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxMixer.SetFloat("volume", volume);
    }
}