using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SongSelectionScript : MonoBehaviour
{
    //public GameObject musicVolObj;

    public GameObject[] songs; //all the songs
    public GameObject songDatabase;
    public int numOfPanels;
    public int activePanelCounter; //the active panel counter

    public GameObject currentSong;
    public SongObjectScript songObjectScript;
    public GameObject SongObject; //the selected song (EmptyObject form)
    public GameObject selectedAudioSource;

    public GameObject songMenu;
    public GameObject difficultyMenu;

    public Text songNameText;

    public AudioSource buttonClickSound;

    public int highScore;
    public Text highScoreText;
    public string perfectScore;
    public GameObject perfectScoreStar;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/ABCRemix"), songDatabase.transform);
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/Absence"), songDatabase.transform);
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/Descent"), songDatabase.transform);
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/Interpulse"), songDatabase.transform);
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/PillarsOfCreation"), songDatabase.transform);
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/PianoCommercialSong"), songDatabase.transform);

        //musicVolObj = GameObject.Find("MusicVolObj");

        FindSongs();

        string savedScoreName = songNameText + "_highscore";
        string savedPerfectScoreName = songNameText + "_perfectScore";

        highScore = PlayerPrefs.GetInt(savedScoreName);
        perfectScore = PlayerPrefs.GetString(savedPerfectScoreName);

        perfectScoreStar.SetActive(false);

        highScoreText.text = "Highscore: " + highScore.ToString();
        if (perfectScore == "true")
        {
            perfectScoreStar.SetActive(true);
        }
        else
        {
            perfectScoreStar.SetActive(false);
        }
    }   
    
    public void FindSongs()
    {
        songMenu.SetActive(true);

        activePanelCounter = 0;

        songs = GameObject.FindGameObjectsWithTag("Song");
        numOfPanels = songs.Length;

        /**
        * Hide all song panels
        */
        foreach (GameObject song in songs)
        {
            song.SetActive(false);
        }

        //Set the first panel active
        songs[activePanelCounter].SetActive(true);

        currentSong = songs[activePanelCounter];
        songObjectScript = currentSong.GetComponent<SongObjectScript>();
        songObjectScript.setupSong();
        songNameText.text = songObjectScript.audioName;
        currentSong.GetComponent<AudioSource>().clip.LoadAudioData();
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

        songs[activePanelCounter].SetActive(false); //make the current panel invisible

        if (activePanelCounter == (songs.Length - 1))
        {
            activePanelCounter = -1;
        }

        songs[activePanelCounter + 1].SetActive(true); //make the next panel visible

        activePanelCounter++; //the next active panel will be the next one in the counter

        currentSong = songs[activePanelCounter];
        songObjectScript = currentSong.GetComponent<SongObjectScript>();
        songObjectScript.setupSong();
        songNameText.text = songObjectScript.audioName;

        highScoreText.text = "Highscore: " + highScore.ToString();
        if (perfectScore == "true")
        {
            perfectScoreStar.SetActive(true);
        }
        else
        {
            perfectScoreStar.SetActive(false);
        }
    }

    public void OnClickPreviousPanel()
    {
        buttonClickSound.Play();

        songs[activePanelCounter].SetActive(false); //make the current panel invisible

        if (activePanelCounter == 0)
        {
            activePanelCounter = songs.Length;
        }

        songs[activePanelCounter - 1].SetActive(true); //make the next panel visible

        activePanelCounter--; //the next active panel will be the next one in the counter

        currentSong = songs[activePanelCounter];
        songObjectScript = currentSong.GetComponent<SongObjectScript>();
        songObjectScript.setupSong();
        songNameText.text = songObjectScript.audioName;

        highScoreText.text = "Highscore: " + highScore.ToString();
        if (perfectScore == "true")
        {
            perfectScoreStar.SetActive(true);
        }
        else
        {
            perfectScoreStar.SetActive(false);
        }
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
        buttonClickSound.Play();

        SongObject = currentSong;
        selectedAudioSource = SongObject;

        songMenu.SetActive(false);
        difficultyMenu.SetActive(true); //enable the difficulty panel
    }

    public void OnClickChooseDifficulty()
    {
        buttonClickSound.Play();

        string difficulty = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text; //get the button text

        if (difficulty == "NORMAL")
        {
            SongObject.GetComponent<SongObjectScript>().difficultyMultiplier = 1;
        } 
        else if (difficulty == "HARD")
        {
            SongObject.GetComponent<SongObjectScript>().difficultyMultiplier = 2;
        }
        else if (difficulty == "INSANE")
        {
            SongObject.GetComponent<SongObjectScript>().difficultyMultiplier = 4;
        }

        SongObject.transform.SetParent(null); //destroy parent object
        selectedAudioSource.transform.SetParent(null);

        if (selectedAudioSource.GetComponent<AudioSource>().isPlaying) selectedAudioSource.GetComponent<AudioSource>().Stop();

        DontDestroyOnLoad(SongObject);
        DontDestroyOnLoad(selectedAudioSource);
        //if (musicVolObj != null) DontDestroyOnLoad(musicVolObj);

        SceneManager.LoadScene("MainGameplay"); //load main scene
    }
}
