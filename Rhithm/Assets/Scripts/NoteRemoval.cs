﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRemoval : MonoBehaviour
{
    public Score score;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Note")
        {
            //score.decreaseScore(); Do we want it to decrease score?
            score.resetNoteStreak();
            score.noteMissed();
        }

        Destroy(other.gameObject);

    }
}