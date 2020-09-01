using System.Globalization;
using UnityEngine;
//using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    private int scoreMultiplier = 1;
    private int noteStreak = 0;
    private bool missedNote = false;

    public void increaseScore()
    {
        score += 1 * scoreMultiplier;
    }

    public void decreaseScore()
    {
        if(score > 0)
        {
            score--;
        }
        scoreMultiplier = 1;
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
    }

    public int getNoteStreak()
    {
        return noteStreak;
    }


    public void increaseScoreMultiplier(int newMultiplier)
    {
        scoreMultiplier = newMultiplier;
        Debug.Log("Multiplier increased!, New Multiplier = " + scoreMultiplier);
    }

}
