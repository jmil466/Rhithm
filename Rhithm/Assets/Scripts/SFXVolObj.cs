using UnityEngine;
using UnityEngine.UI;

public class SFXVolObj : MonoBehaviour
{
    public Slider sfxSlider;
    public float sfxVolValue;

    void Start()
    {
        sfxVolValue = sfxSlider.value;
    }

    void Update()
    {
        if (sfxSlider != null)
        {
            sfxVolValue = sfxSlider.value;
        }
    }

    public float getSfxVolValue()
    {
        return sfxVolValue;
    }
}
