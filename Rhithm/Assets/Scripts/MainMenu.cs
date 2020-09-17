using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public float musicVolValue { get; set; }
    //public float musicVolValue;
    public GameObject musicVolObj;

    public void Play()
    {
        DontDestroyOnLoad(musicVolObj);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}