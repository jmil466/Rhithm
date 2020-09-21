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

    // Update is called once per frame
    void Update()
    {
        
    }
}
