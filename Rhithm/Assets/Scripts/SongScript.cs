using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SongScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public string audioName;
    public float audioLength;
    public Text audioTextName;

    // Start is called before the first frame update
    void Start()
    {
        audioClip = audioSource.clip;
        audioLength = audioClip.length;
        audioName = audioClip.name;
        audioTextName.text = audioName;
    }

    public void OnClickPlaySong()
    {
        audioSource.Play();

        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (10)); //Play for 10 seconds from 0 seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
