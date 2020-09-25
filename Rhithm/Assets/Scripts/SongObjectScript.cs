using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongObjectScript : MonoBehaviour
{
    //public GameObject theSongPanel;
    //SongDisplayScript songDisplayScript;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float BPM; //beats per minute
    public float startDelay;
    public float audioLength;
    public float difficultyMultiplier;
    private int highScore; // Added by James
    public string audioName;
    public string songKey;

    // Start is called before the first frame update
    void Start()
    {
        audioClip = audioSource.clip;
        audioLength = audioClip.length;
        audioName = audioClip.name;

        //songDisplayScript = theSongPanel.GetComponent<SongDisplayScript>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   /* public SongObjectScript(AudioSource song, float songBPM) // Constructor for testing
    {
        audioSource = song;
        audioClip = audioSource.clip;
        audioLength = audioClip.length;
        BPM = songBPM;

    } */

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
}
