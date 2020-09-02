using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    private int scoreMultiplier = 1;
    private int noteStreak = 0;
    private bool missedNote = false;

    public Text scoreText;
    public Text multiplierText;

    void Start()
    { 


        updateScoreText();
        updateMultiplierText();
    }


    public void increaseScore()
    {
        score += 1 * scoreMultiplier;
        updateScoreText();
    }

    public void decreaseScore()
    {
        if(score > 0)
        {
            score--;
        }
        scoreMultiplier = 1;

        updateScoreText();
        updateMultiplierText();
    }

    public int getScore()
    {
        return score;
    }

    public void noteMissed()
    {
        missedNote = true;
    }

    public void increaseNoteStreak()
    {
        noteStreak++;
    }

    public void resetNoteStreak()
    {
        noteStreak = 0;
        scoreMultiplier = 1;
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


}
