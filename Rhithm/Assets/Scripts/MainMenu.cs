using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject musicVolObj;
    public GameObject sfxVolObj;

    public void Play()
    {
        musicVolObj = GameObject.Find("MusicVolObj");
        sfxVolObj = GameObject.Find("SFXVolObj");

        MusicVolObj MusicVolObjScript = musicVolObj.GetComponent<MusicVolObj>();
        SFXVolObj SFXVolObjScript = sfxVolObj.GetComponent<SFXVolObj>();

        MusicVolObjScript.musicSlider = null;
        SFXVolObjScript.sfxSlider = null;

        DontDestroyOnLoad(musicVolObj);
        DontDestroyOnLoad(sfxVolObj);

        SceneManager.LoadScene("SongListDemo");
    }
}