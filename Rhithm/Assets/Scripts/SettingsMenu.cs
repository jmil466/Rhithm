using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;
    public GameObject musicVolObj;
    public GameObject sfxVolObj;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        musicVolObj = GameObject.Find("MusicVolObj");
        musicSlider = (Slider)GameObject.FindObjectsOfType(typeof(Slider))[0];

        musicSlider.value = musicVolObj.GetComponent<MusicVolObj>().musicVolValue;
        musicVolObj.GetComponent<MusicVolObj>().musicSlider = musicSlider;

        sfxVolObj = GameObject.Find("SFXVolObj");
        sfxSlider = (Slider)GameObject.FindObjectsOfType(typeof(Slider))[1];

        sfxSlider.value = sfxVolObj.GetComponent<SFXVolObj>().sfxVolValue;
        sfxVolObj.GetComponent<SFXVolObj>().sfxSlider = sfxSlider;
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