using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestScript : MonoBehaviour
{
    public Score score;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Note")
        {
            score.increaseScore();
            score.increaseNoteStreak();
            if (score.getNoteStreak() >= 5 && score.getNoteStreak() < 15)
            {
                score.increaseScoreMultiplier(2);
            }
            else if (score.getNoteStreak() >= 15)
            {
                score.increaseScoreMultiplier(4);
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
