using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public float musicVolValue { get; set; }
    //public float musicVolValue;
    public GameObject musicVolObj;

    public void Play()
    {
        MusicVolObj MusicVolObjScript = musicVolObj.GetComponent<MusicVolObj>();

        DontDestroyOnLoad(musicVolObj);

        MusicVolObjScript.musicSlider = null;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}