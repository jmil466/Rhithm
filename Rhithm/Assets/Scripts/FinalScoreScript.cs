using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreScript : MonoBehaviour
{
    public int currentHighScore;
    public int userScore;
    public string songName;

    public void CalculateFinalScore()
    {
        CompletionScript completionScript = GameObject.Find("CompletionUI").GetComponent<CompletionScript>();
        SongObjectScript songObjectScript = (SongObjectScript)FindObjectOfType(typeof(SongObjectScript));

        currentHighScore = completionScript.getHighScore();
        userScore = completionScript.getUserScore();
        songName = songObjectScript.GetSongName();
    }
}
