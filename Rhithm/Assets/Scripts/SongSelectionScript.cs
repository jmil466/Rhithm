using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SongSelectionScript : MonoBehaviour
{
    private GameObject[] songs; //all the songs
    public GameObject songDatabase;
    private int numOfSongs;
    private int activeSongCounter; //the active song counter

    public Text songNameText;
    private GameObject currentSong;
    private SongObjectScript songObjectScript;
    private GameObject SongObject; //the selected song (EmptyObject form)
    private GameObject selectedAudioSource;

    public GameObject songMenu;
    public GameObject difficultyMenu;

    public AudioSource buttonClickSound;

    public Text highScoreText;
    public GameObject stars;
    public GameObject NormalStar;
    public GameObject HardStar;
    public GameObject InsaneStar;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Coins: " + PlayerPrefs.GetInt("Coins"));

        InstantiateSongObjects();
        FindSongs();
        AssignCurrentSong();
        ShowSongHighScore();
    }   
    
    public void InstantiateSongObjects()
    {
        songs = Resources.LoadAll<GameObject>("Prefabs/Audio");

        foreach (GameObject song in songs)
        {
            Instantiate(song, songDatabase.transform);
        }
    }
    public void FindSongs()
    {
        songMenu.SetActive(true);

        activeSongCounter = 0;

        songs = GameObject.FindGameObjectsWithTag("Song");
        numOfSongs = songs.Length;

        /**
        * Hide all song panels
        */
        foreach (GameObject song in songs)
        {
            song.SetActive(false);
        }

        //Show the first song
        songs[activeSongCounter].SetActive(true);
    }

    public void OnClickMenu()
    {
        buttonClickSound.Play();

        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickMute()
    {
        buttonClickSound.Play();

        buttonClickSound.mute = !buttonClickSound.mute;
        currentSong.GetComponent<AudioSource>().mute = !currentSong.GetComponent<AudioSource>().mute;
    }

    public void OnClickNextPanel()
    {
        buttonClickSound.Play();

        songs[activeSongCounter].SetActive(false); //make the current panel invisible

        if (activeSongCounter == (songs.Length - 1))
        {
            activeSongCounter = -1;
        }

        songs[activeSongCounter + 1].SetActive(true); //make the next panel visible

        activeSongCounter++; //the next active panel will be the next one in the counter

        AssignCurrentSong();
        ShowSongHighScore();
    }

    public void OnClickPreviousPanel()
    {
        buttonClickSound.Play();

        songs[activeSongCounter].SetActive(false); //make the current panel invisible

        if (activeSongCounter == 0)
        {
            activeSongCounter = songs.Length;
        }

        songs[activeSongCounter - 1].SetActive(true); //make the next panel visible

        activeSongCounter--; //the next active panel will be the next one in the counter

        AssignCurrentSong();
        ShowSongHighScore();
    }

    public void onClickPreviewSong()
    {
        buttonClickSound.Play();

        currentSong.GetComponent<AudioSource>().clip.LoadAudioData();

        currentSong.GetComponent<AudioSource>().Play();

        currentSong.GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (30-20)); //Play for 10 seconds from 0 seconds
    }

    public void OnClickPlaySong()
    {
        currentSong.GetComponent<AudioSource>().clip.LoadAudioData();
        difficultyMenu.SetActive(true);
        stars.SetActive(false);
        buttonClickSound.Play();

        SongObject = currentSong;
        selectedAudioSource = SongObject;

        songMenu.SetActive(false);
        difficultyMenu.SetActive(true); //enable the difficulty panel
    }

    public void OnClickChooseDifficulty()
    {
        buttonClickSound.Play();

        string difficulty = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text; //get the button text of clicked button

        if (difficulty == "NORMAL")
        {
            SongObject.GetComponent<SongObjectScript>().SetDifficultyMultiplier(1f);
        } 
        else if (difficulty == "HARD")
        {
            SongObject.GetComponent<SongObjectScript>().SetDifficultyMultiplier(2f);
        }
        else if (difficulty == "INSANE")
        {
            SongObject.GetComponent<SongObjectScript>().SetDifficultyMultiplier(4f);
        }

        SongObject.transform.SetParent(null); //destroy parent object
        selectedAudioSource.transform.SetParent(null);

        if (selectedAudioSource.GetComponent<AudioSource>().isPlaying) selectedAudioSource.GetComponent<AudioSource>().Stop();

        DontDestroyOnLoad(SongObject);
        DontDestroyOnLoad(selectedAudioSource);

        SceneManager.LoadScene("MainGameplay"); //load main scene
    }

    void AssignCurrentSong()
    {
        currentSong = songs[activeSongCounter];
        songObjectScript = currentSong.GetComponent<SongObjectScript>();
        songObjectScript.setupSong();
        songNameText.text = songObjectScript.GetSongName();
    }

    void ShowSongHighScore()
    {
        highScoreText.text = "Highscore: " + songObjectScript.GetSongHighScore().ToString();

        if (songObjectScript.IsNormalFullCombo())
        {
            NormalStar.SetActive(true);
        }
        else
        {
            NormalStar.SetActive(false);
        }

        if (songObjectScript.IsHardFullCombo())
        {
            HardStar.SetActive(true);
        }
        else
        {
            HardStar.SetActive(false);
        }

        if (songObjectScript.IsInsaneFullCombo())
        {
          InsaneStar.SetActive(true);
        }
        else
        {
            InsaneStar.SetActive(false);
        }
    }

    public GameObject[] GetSongs()
    {
        return songs;
    }

    public int GetNumOfSongs()
    {
        return numOfSongs;
    }

    public int GetActiveSongCounter()
    {
        return activeSongCounter;
    }

    public void SetActiveSongCounter(int counter)
    {
        activeSongCounter = counter;
    }

    public GameObject GetCurrentSong()
    {
        return currentSong;
    }
}
