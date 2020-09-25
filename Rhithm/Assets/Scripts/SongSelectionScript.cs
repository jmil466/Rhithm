using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SongSelectionScript : MonoBehaviour
{
    public GameObject[] songPanels; //all the song panels
    public int numOfPanels;
    public SongDisplayScript SDS;
    public GameObject selectedSongObject; //the selected song (EmptyObject form)
    public GameObject selectedAudioSource;
    public GameObject difficultyMenu;
    public GameObject songMenu;
    public AudioSource currentSongAudioSource;
    public AudioSource buttonClickSound;
    public int activePanelCounter; //the active panel counter
    public GameObject musicVolObj;

    // Start is called before the first frame update
    void Start()
    {  
        musicVolObj = GameObject.Find("MusicVolObj");

        SetSongPanels();
    }
    
    public void SetSongPanels()
    {
        songMenu.SetActive(true);
        difficultyMenu.SetActive(false);

        activePanelCounter = 0;

        songPanels = GameObject.FindGameObjectsWithTag("SongPanel");
        numOfPanels = songPanels.Length;

        /**
        * Hide all song panels
        */
        foreach (GameObject songs in songPanels)
        {
            songs.SetActive(false);
        }

        //Set the first panel active
        songPanels[activePanelCounter].SetActive(true);
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
        currentSongAudioSource = songPanels[activePanelCounter].GetComponentInChildren<AudioSource>();
        currentSongAudioSource.mute = !currentSongAudioSource.mute;
    }

    public void OnClickNextPanel()
    {
        buttonClickSound.Play();

        songPanels[activePanelCounter].SetActive(false); //make the current panel invisible

        if (activePanelCounter == (songPanels.Length - 1))
        {
            activePanelCounter = -1;
        }

        songPanels[activePanelCounter + 1].SetActive(true); //make the next panel visible

        activePanelCounter++; //the next active panel will be the next one in the counter
    }

    public void OnClickPreviousPanel()
    {
        buttonClickSound.Play();

        songPanels[activePanelCounter].SetActive(false); //make the current panel invisible

        if (activePanelCounter == 0)
        {
            activePanelCounter = songPanels.Length;
        }

        songPanels[activePanelCounter - 1].SetActive(true); //make the next panel visible

        activePanelCounter--; //the next active panel will be the next one in the counter
    }

    public void onClickPreviewSong()
    {
        buttonClickSound.Play();

        SDS = songPanels[activePanelCounter].GetComponent<SongDisplayScript>();

        SDS.audioSource.Play();

        SDS.audioSource.SetScheduledEndTime(AudioSettings.dspTime + (10)); //Play for 10 seconds from 0 seconds
    }

    public void OnClickPlaySong()
    {
        buttonClickSound.Play();

        selectedSongObject = GameObject.FindGameObjectWithTag("SongObject"); //Find the active song object
        selectedAudioSource = GameObject.FindGameObjectWithTag("Song"); //Find the active audio source

        //songPanels[activePanelCounter].SetActive(false); //hide panel
        //GameObject.FindGameObjectWithTag("PreviousNextPanel").SetActive(false); //hide Previous and Next buttons
        //GameObject.FindGameObjectWithTag("PreviewPlayPanel").SetActive(false); //hide Preview and Play buttons

        songMenu.SetActive(false);
        difficultyMenu.SetActive(true); //enable the difficulty panel
    }

    public void OnClickChooseDifficulty()
    {
        buttonClickSound.Play();

        string difficulty = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text; //get the button text

        if (difficulty == "NORMAL")
        {
            selectedSongObject.GetComponent<SongObjectScript>().difficultyMultiplier = 1;
        } 
        else if (difficulty == "HARD")
        {
            selectedSongObject.GetComponent<SongObjectScript>().difficultyMultiplier = 2;
        }
        else if (difficulty == "INSANE")
        {
            selectedSongObject.GetComponent<SongObjectScript>().difficultyMultiplier = 4;
        }

        //UnityEngine.Debug.Log(selectedSongObject);

        //selectedSongObject.transform.parent = null; //destroy parent object
        selectedSongObject.transform.SetParent(null); //destroy parent object
        selectedAudioSource.transform.SetParent(null);

        if (selectedAudioSource.GetComponent<AudioSource>().isPlaying) selectedAudioSource.GetComponent<AudioSource>().Stop();

        DontDestroyOnLoad(selectedSongObject);
        DontDestroyOnLoad(selectedAudioSource);
        if (musicVolObj != null) DontDestroyOnLoad(musicVolObj);

        SceneManager.LoadScene("MainGameplay"); //load main scene
    }
}
