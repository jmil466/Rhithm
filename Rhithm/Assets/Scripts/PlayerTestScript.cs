using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestScript : MonoBehaviour
{
    public Score score;
    public int multiplierStreakOne;
    public int multiplierStreakTwo;
    public int multiplierStreakThree;
    public int multiplierStreakFour;

    void Start()
    {
        if(multiplierStreakOne == 0)
        {
            multiplierStreakOne = 5;
        }
        if (multiplierStreakTwo == 0)
        {
            multiplierStreakTwo = (multiplierStreakOne + 10);
        }
        if (multiplierStreakThree == 0)
        {
            multiplierStreakThree = (multiplierStreakTwo + 15);
        }
        if (multiplierStreakFour == 0)
        {
            multiplierStreakFour = (multiplierStreakThree + 20);
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Note")
        {
            score.increaseScore();
            score.increaseNoteStreak();
            if (score.getNoteStreak() >= multiplierStreakOne && score.getNoteStreak() < multiplierStreakTwo)
            {
                score.increaseScoreMultiplier(2);
            }
            else if (score.getNoteStreak() >= multiplierStreakTwo && score.getNoteStreak() < multiplierStreakThree)
            {
                score.increaseScoreMultiplier(4);
            }
            else if (score.getNoteStreak() >= multiplierStreakThree && score.getNoteStreak() < multiplierStreakFour)
            {
                score.increaseScoreMultiplier(6);
            }
            else if (score.getNoteStreak() >= multiplierStreakFour)
            {
                score.increaseScoreMultiplier(8);
            }

        }
        else if(other.gameObject.tag == "Obstacle")
        {
            score.decreaseScore();
            score.resetNoteStreak();
        }

        Destroy(other.gameObject);
    }
}
