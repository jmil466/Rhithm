using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SongSelectionScript : MonoBehaviour
{
    public GameObject[] songPanels; //all the song panels
    public GameObject selectedSongObject; //the selected song (EmptyObject form)
    public GameObject selectedSongAudioSource; //the selected song (AudioSource form)
    public GameObject difficultyPanel;
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
    
    public void nextPanel()
    {
        songPanels[activePanelCounter].SetActive(false); //make the current panel invisible

        if (activePanelCounter == (songPanels.Length - 1))
        {
            activePanelCounter = -1;
        }

        songPanels[activePanelCounter + 1].SetActive(true); //make the next panel visible

        activePanelCounter++; //the next active panel will be the next one in the counter
    }

    public void previousPanel()
    {
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

    public void OnClickPlaySong()
    {
        selectedSongObject = GameObject.FindGameObjectWithTag("SongObject");
        selectedSongAudioSource = GameObject.FindGameObjectWithTag("Song");

        songPanels[activePanelCounter].SetActive(false); //hide panel
        GameObject.FindGameObjectWithTag("PreviousNextPanel").SetActive(false); //hide panel
        difficultyPanel.SetActive(true); //enable the difficulty panel 
    }

    public void OnClickChooseDifficulty()
    {
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

        selectedSongObject.transform.parent = null; //destroy parent object
        selectedSongAudioSource.transform.parent = null; //destroy parent object

        selectedSongAudioSource.SetActive(false); //stop audio if playing
        selectedSongAudioSource.SetActive(true); //set active

        DontDestroyOnLoad(selectedSongObject);
        DontDestroyOnLoad(selectedSongAudioSource);

        SceneManager.LoadScene("MainGameplay"); //load main scene
    }
}
