using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SongDisplayScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public string audioName;
    public Text audioTextName;

    // Start is called before the first frame update
    void Start()
    {
        audioClip = audioSource.clip;
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
