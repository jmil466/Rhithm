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

    // Start is called before the first frame update
    void Start()
    {
        audioClip = audioSource.clip;
        audioLength = audioClip.length;

        //songDisplayScript = theSongPanel.GetComponent<SongDisplayScript>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAudio()
    {
        audioSource.Play();
    }

    public void pauseAudio()
    {
        audioSource.Pause();
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
}
