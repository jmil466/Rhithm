using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public SongObjectScript song;
    public AudioSource buttonClickSound;

    void Start()
    {
        song = findSong();
    }

    private SongObjectScript findSong()
    {
        return (SongObjectScript)FindObjectOfType(typeof(SongObjectScript));

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        song.PlayAudio();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        song.PauseAudio();
    }

    public void Restart()
    {
        song.StopAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        song.StopAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }

    public void OnClickMute()
    {
        buttonClickSound.mute = !buttonClickSound.mute;

        GameObject songObject = GameObject.Find("SongObject");

        SongObjectScript songObjectScript = songObject.GetComponent<SongObjectScript>();

        AudioSource currentSong = songObjectScript.GetAudioSource();

        currentSong.mute = !currentSong.mute;
    }
}