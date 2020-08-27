using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BeatCollision : MonoBehaviour
{
    public int score = 0;
    public Movement player;

    void OnTriggerStay(Collider colInfo)
    {
        if (colInfo.gameObject.tag == "Red Beat")
        {
            if(player.pickup == true)
            {
                UnityEngine.Debug.Log("Red Beat hit!");
                Destroy(colInfo.gameObject);
                score++;
            }
        }

        if (colInfo.gameObject.tag == "Blue Beat")
        {
            if (player.pickup == true)
            {
                UnityEngine.Debug.Log("Blue Beat hit!");
                Destroy(colInfo.gameObject);
                score++;
            }
        }

        if (colInfo.gameObject.tag == "Green Beat")
      
            if (player.pickup == true)
            {
                UnityEngine.Debug.Log("Green Beat hit!");
                Destroy(colInfo.gameObject);
                score++;
            }

        UnityEngine.Debug.Log("Score is " + score);
    }
        
}
