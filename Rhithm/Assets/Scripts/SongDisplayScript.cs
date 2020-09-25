using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SongDisplayScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public string audioName;
    public Text audioTextName;
    public int highScore;
    public Text highScoreText;
    public string perfectScore;
    public GameObject perfectScoreStar;
    

    // Start is called before the first frame update
    void Start()
    {
        audioClip = audioSource.clip;
        audioName = audioClip.name;
        string savedScoreName = audioName + "_highscore";
        string savedPerfectScoreName = audioName + "__perfectScore";

        highScore = PlayerPrefs.GetInt(savedScoreName);
        perfectScore = PlayerPrefs.GetString(savedPerfectScoreName);

        perfectScoreStar.SetActive(false);

        Debug.Log(audioName + " Hs: " + highScore + " Perfect?: " + perfectScore);
    }

    // Update is called once per frame
    void Update()
    {
        audioTextName.text = audioName;
        highScoreText.text = "Highscore: " + highScore.ToString();
        if (perfectScore == "true")
        {
            perfectScoreStar.SetActive(true);
        }

    }
}
