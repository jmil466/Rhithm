﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongObjectScript : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioClip audioClip;
    private string audioName;
    public float BPM; //beats per minute
    public float startDelay;
    private float audioLength;
    private float difficultyMultiplier;
    private int highScore; // Added by James
    private string songPerfectScore; //Added by Rafael

    // Start is called before the first frame update
    void Start()
    {
        setupSong();
    }

    public void setupSong()
    {
        audioClip = audioSource.clip;
        audioName = audioClip.name;
        audioLength = audioClip.length;
        //audioLength = 10f; //testing purposes
        string savedScoreName = audioName + "_highscore";
        highScore = PlayerPrefs.GetInt(savedScoreName);
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

    public void SetDifficultyMultiplier(float num)
    {
        difficultyMultiplier = num;
    }

    public int GetSongHighScore()
    {
        string savedScoreName = audioName + "_highscore";
        highScore = PlayerPrefs.GetInt(savedScoreName);

        return highScore;
    }

    public string GetSongName()
    {
        return audioName;
    }

    public bool IsPerfectScore()
    {
        string savedPerfectScoreName = audioName + "_perfectscore";
        songPerfectScore = PlayerPrefs.GetString(savedPerfectScoreName);

        if (songPerfectScore == "true")
        {
            return true;
        }
        else
        {
            Debug.Log("audio name: " + audioName);
            Debug.Log("Not a perfect score" + songPerfectScore);
            return false;
        }
    }

    public bool IsNormalFullCombo()
    {
        string savedPerfectScoreName = audioName + "_normal_perfectscore";
        songPerfectScore = PlayerPrefs.GetString(savedPerfectScoreName);

        if (songPerfectScore == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsHardFullCombo()
    {
        string savedPerfectScoreName = audioName + "_hard_perfectscore";
        songPerfectScore = PlayerPrefs.GetString(savedPerfectScoreName);

        if (songPerfectScore == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsInsaneFullCombo()
    {
        string savedPerfectScoreName = audioName + "_insane_perfectscore";
        songPerfectScore = PlayerPrefs.GetString(savedPerfectScoreName);

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
