using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    private int scoreMultiplier = 1;
    private int noteStreak = 0;
    private bool missedNote = false;


    private SongObjectScript song;
    private int highScore;

    public Text scoreText;
    public Text multiplierText;
    public SaveSongData songData;


    void Start()
    {
        score = 0;
        updateScoreText();
        updateMultiplierText();
        findHighScore();
    }

    private void findHighScore()
    {
        song = (SongObjectScript)FindObjectOfType(typeof(SongObjectScript));
        highScore = song.GetSongHighScore();
    }


    public void increaseScore()
    {
        score += (1 * scoreMultiplier);
        updateScoreText();
    }


    public int getScore()
    {
        return score;
    }

    public void noteMissed()
    {
        missedNote = true;
    }

    public bool getNoteMissed()
    {
        return missedNote;
    }

    public void increaseNoteStreak()
    {
        noteStreak++;
    }

    public void resetNoteStreak()
    {
        noteStreak = 0;
        scoreMultiplier = 1;
        noteMissed();
        updateMultiplierText();
    }

    public int getNoteStreak()
    {
        return noteStreak;
    }


    public void increaseScoreMultiplier(int newMultiplier)
    {
        scoreMultiplier = newMultiplier;
        updateMultiplierText();
    }

    private void updateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void updateMultiplierText()
    {
        multiplierText.text = scoreMultiplier.ToString() + "x";
    }

    public int getHighScore()
    {
        return highScore;
    }

    public int calculateHighScore()
    { 

        Debug.Log("Current score: " + score + ", High Score was: " + highScore);
        if(score > highScore)
        {
            songData.saveHighScore(score);
            highScore = score;
            return score;

        } else
        {
            songData.saveHighScore(highScore);
            return highScore;
        }



    
    }

}
