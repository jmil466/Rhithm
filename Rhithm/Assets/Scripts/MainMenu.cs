using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject musicVolObj;
    public GameObject sfxVolObj;

    void Awake()
    {
        PlayerPrefs.DeleteAll();
        checkFirstVisit();
        devRoom();
    }

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

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    private void checkFirstVisit()
    {
        if (PlayerPrefs.GetInt("PlayerCubeWhitePurchased") == 0) //Not purchased
        {
            Debug.Log("This is user's first run of the game, setting first visit key...");
            PlayerPrefs.SetInt("PlayerCubeWhitePurchased", -1); //-1 is a key for first time visit, and has not visited shop
            Debug.Log("First visit key: " + PlayerPrefs.GetInt("PlayerCubeWhitePurchased"));
        }
    }

    private void devRoom()
    {
        PlayerPrefs.SetInt("Coins", 99999);
    }
}