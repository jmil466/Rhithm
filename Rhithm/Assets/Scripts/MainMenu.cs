using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject musicVolObj;
    public GameObject sfxVolObj;

    public void Play()
    {
        MusicVolObj MusicVolObjScript = musicVolObj.GetComponent<MusicVolObj>();
        SFXVolObj SFXVolObjScript = sfxVolObj.GetComponent<SFXVolObj>();

        DontDestroyOnLoad(musicVolObj);
        DontDestroyOnLoad(sfxVolObj);

        MusicVolObjScript.musicSlider = null;
        SFXVolObjScript.sfxSlider = null;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}