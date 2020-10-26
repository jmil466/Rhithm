using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongObjectScript : MonoBehaviour
{
    //public GameObject theSongPanel;
    //SongDisplayScript songDisplayScript;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public string audioName;
    public float BPM; //beats per minute
    public float startDelay;
    public float audioLength;
    public float difficultyMultiplier;
    private int highScore; // Added by James
    private string songPerfectScore; //Added by Rafael

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();
        setupSong();

        //songDisplayScript = theSongPanel.GetComponent<SongDisplayScript>();
    }
    // Update is called once per frame

    public void setupSong()
    {
        audioClip = audioSource.clip;
        audioName = audioClip.name;
        Debug.Log("setupSong(): audioName = " + audioName);
        audioLength = audioClip.length;
        string savedScoreName = audioName + "_highscore";
        highScore = PlayerPrefs.GetInt(savedScoreName);
        Debug.Log("Highscore: " + highScore);
        Debug.Log("Audio name: " + audioName);
        string savedPerfectScoreName = audioName + "_perfectscore";
        songPerfectScore = PlayerPrefs.GetString(savedPerfectScoreName);
    }

    public AudioSource GetAudioSource()
    {
        return audioSource;
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void PauseAudio()
    {
        audioSource.Pause();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public float GetBPM()
    {
        return BPM;
    }

    public float GetStartDelay()
    {
        return startDelay;
    }

    public float GetAudioLength()
    {
        return audioLength;
    }
    
    public float GetDifficultyMultiplier()
    {
        return difficultyMultiplier;
    }

    public int GetSongHighScore()
    {
        return highScore;
    }
    
    public string GetSongName()
    {
        return audioName;
    }

    public bool IsPerfectScore()
    {
        if (songPerfectScore == "true")
        {
            return true;
        }
        else
        {
            return false;      
        }       
    }
}
