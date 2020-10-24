using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button pauseButton;
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
        pauseButton.interactable = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        song.PlayAudio();
    }

    public void Pause()
    {
        pauseButton.interactable = false;
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
        GameObject songGameObject = GameObject.FindGameObjectWithTag("Song");
        Destroy(songGameObject);
        SceneManager.LoadScene("SongListDemo");
        Time.timeScale = 1f;
    }

    public void OnClickMute()
    {
        buttonClickSound.Play();

        buttonClickSound.mute = !buttonClickSound.mute;

        GameObject songObject = GameObject.Find("SongObject");

        SongObjectScript songObjectScript = songObject.GetComponent<SongObjectScript>();

        AudioSource currentSong = songObjectScript.GetAudioSource();

        currentSong.mute = !currentSong.mute;
    }
}