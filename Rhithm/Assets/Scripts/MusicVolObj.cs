using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolObj : MonoBehaviour
{
    public Slider musicSlider;
    public float musicVolValue;
     

    void Update()
    {
        musicVolValue = musicSlider.value;
    }

    public float getMusicVolValue()
    {
        return musicVolValue;
    }
}