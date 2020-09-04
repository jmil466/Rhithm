using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelectionScript : MonoBehaviour
{
    public GameObject[] songPanels; //all the song panels
    public GameObject selectedSongObject; //the selected song (EmptyObject form)
    public GameObject selectedSongAudioSource; //the selected song (AudioSource form)
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

        UnityEngine.Debug.Log(selectedSongObject);

        selectedSongObject.transform.parent = null; //destory parent object
        selectedSongAudioSource.transform.parent = null;

        DontDestroyOnLoad(selectedSongObject);
        DontDestroyOnLoad(selectedSongAudioSource);

        SceneManager.LoadScene("MainGameplay");
    }
}
