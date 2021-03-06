﻿using System.Collections;
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
        audioSource = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();

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
        highScoreText.text = "Highscore: " + highScore.ToString();
        if (perfectScore == "true")
        {
            perfectScoreStar.SetActive(true);
        } else
        {
            perfectScoreStar.SetActive(false);
        }

    }
}
