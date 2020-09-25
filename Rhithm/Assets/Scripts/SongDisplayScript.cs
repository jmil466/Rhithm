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
        string savedScoreName = audioName + "_highscore";
        string savedPerfectScoreName = audioName + "_perfectScore";

        highScore = PlayerPrefs.GetInt(savedScoreName);
        perfectScore = PlayerPrefs.GetString(savedPerfectScoreName);

        perfectScoreStar.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        audioTextName.text = audioName;
    }
}
