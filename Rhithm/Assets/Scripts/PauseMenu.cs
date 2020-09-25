using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public SongObjectScript song;
    public GameObject pauseMenu;
    public Button pauseButton;

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
        song.playAudio();
    }

    public void Pause()
    {
        pauseButton.interactable = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        song.pauseAudio();
    }

    public void Restart()
    {
        song.stopAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        song.StopAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }
}