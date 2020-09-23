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

    public void playAudio()
    {
        audioSource.Play();
    }

    public void pauseAudio()
    {
        audioSource.Pause();
    }

    public void stopAudio()
    {
        audioSource.Stop();
    }

    public float getBPM()
    {
        return BPM;
    }

    public float getStartDelay()
    {
        return startDelay;
    }

    public float getAudioLength()
    {
        return audioLength;
    }
    
    public float getDifficultyMultiplier()
    {
        return difficultyMultiplier;
    }

    public int getSongHighScore()
    {
        return highScore;
    }
    
}
