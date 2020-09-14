using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRemoval : MonoBehaviour
{
    public Score score;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Note")
        {
            score.resetNoteStreak();
            score.noteMissed();
            Debug.Log("NOTE COLLISION");
        } else
        {
            Debug.Log("SPIKE COLLISION");
        }

        Destroy(other.gameObject);

    }
}
