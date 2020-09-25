using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button pauseButton;
    public GameObject pauseMenu;
    public SongObjectScript song;
    public AudioSource buttonClickSound;
    public RawImage soundImage;
    private bool isMute = false;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }

    public void OnClickMute()
    {
        buttonClickSound.Play();

        if(isMute)
        {
            buttonClickSound.mute = !buttonClickSound.mute;

            GameObject songObject = GameObject.Find("SongObject");
            SongObjectScript songObjectScript = songObject.GetComponent<SongObjectScript>();
            AudioSource currentSong = songObjectScript.GetAudioSource();
            currentSong.mute = !currentSong.mute;

            soundImage.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
            isMute = !isMute;
        }
        else
        {
            buttonClickSound.mute = !buttonClickSound.mute;

            GameObject songObject = GameObject.Find("SongObject");
            SongObjectScript songObjectScript = songObject.GetComponent<SongObjectScript>();
            AudioSource currentSong = songObjectScript.GetAudioSource();
            currentSong.mute = !currentSong.mute;

            soundImage.GetComponent<RawImage>().color = new Color32(0, 0, 0, 74);
            isMute = !isMute;
        }
        
    }
}