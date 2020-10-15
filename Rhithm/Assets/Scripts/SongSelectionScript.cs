using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SongSelectionScript : MonoBehaviour
{
    public GameObject musicVolObj;

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

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/ABCRemix"), songDatabase.transform);
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/Absence"), songDatabase.transform);
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/Descent"), songDatabase.transform);
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/Interpulse"), songDatabase.transform);
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/PillarsOfCreation"), songDatabase.transform);
        Instantiate(Resources.Load<AudioSource>("Prefabs/Audio/PianoCommercialSong"), songDatabase.transform);

        musicVolObj = GameObject.Find("MusicVolObj");

        FindSongs();
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
        currentSong.GetComponent<AudioSource>().clip.LoadAudioData();
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
        currentSong.GetComponent<AudioSource>().clip.LoadAudioData();
    }

    public void onClickPreviewSong()
    {
        buttonClickSound.Play();

        currentSong.GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (30-20)); //Play for 10 seconds from 0 seconds
    }

    public void OnClickPlaySong()
    {
        difficultyMenu.SetActive(true);
        buttonClickSound.Play();

        //selectedSongObject = GameObject.FindGameObjectWithTag("SongObject"); //Find the active song object
        //selectedAudioSource = GameObject.FindGameObjectWithTag("Song"); //Find the active audio source

        //songPanels[activePanelCounter].SetActive(false); //hide panel
        //GameObject.FindGameObjectWithTag("PreviousNextPanel").SetActive(false); //hide Previous and Next buttons
        //GameObject.FindGameObjectWithTag("PreviewPlayPanel").SetActive(false); //hide Preview and Play buttons

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

        //UnityEngine.Debug.Log(selectedSongObject);
        //selectedSongObject.transform.parent = null; //destroy parent object
        SongObject.transform.SetParent(null); //destroy parent object
        selectedAudioSource.transform.SetParent(null);

        if (selectedAudioSource.GetComponent<AudioSource>().isPlaying) selectedAudioSource.GetComponent<AudioSource>().Stop();

        DontDestroyOnLoad(SongObject);
        DontDestroyOnLoad(selectedAudioSource);
        if (musicVolObj != null) DontDestroyOnLoad(musicVolObj);

        SceneManager.LoadScene("MainGameplay"); //load main scene
    }
}
