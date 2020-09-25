using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SongSelectionScript : MonoBehaviour
{
    public GameObject[] songPanels; //all the song panels
    public SongDisplayScript SDS;
    public GameObject selectedSongObject; //the selected song (EmptyObject form)
    public GameObject selectedSongAudioSource; //the selected song (AudioSource form)
    public GameObject difficultyPanel;
    public AudioSource buttonClickSound;
    public int activePanelCounter = 0; //the active panel counter

    // Start is called before the first frame update
    void Start()
    {
        songPanels = GameObject.FindGameObjectsWithTag("SongPanel");

        /**
         * Hide all song panels
         */
        foreach (GameObject songs in songPanels)
        {
            songs.SetActive(false);
        }

        //Set the first panel active
        songPanels[activePanelCounter].SetActive(true);

        difficultyPanel = GameObject.FindGameObjectWithTag("DifficultyPanel");

        difficultyPanel.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {

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
        selectedSongAudioSource = GameObject.FindGameObjectWithTag("Song"); //Find the active audio source

        songPanels[activePanelCounter].SetActive(false); //hide panel
        GameObject.FindGameObjectWithTag("PreviousNextPanel").SetActive(false); //hide Previous and Next buttons
        GameObject.FindGameObjectWithTag("PreviewPlayPanel").SetActive(false); //hide Preview and Play buttons
        difficultyPanel.SetActive(true); //enable the difficulty panel 
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
        //selectedSongAudioSource.transform.parent = null; //destroy parent object
        selectedSongAudioSource.transform.SetParent(null); //destroy parent object

        selectedSongAudioSource.SetActive(false); //stop audio if playing
        selectedSongAudioSource.SetActive(true); //set active

        DontDestroyOnLoad(selectedSongObject);
        DontDestroyOnLoad(selectedSongAudioSource);

        SceneManager.LoadScene("MainGameplay"); //load main scene
    }
}
