using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class noteSpawner : MonoBehaviour
{
    public GameObject redNote;
    public GameObject blueNote;
    public GameObject greenNote;
    public float max = 10f;
    public static float xAxis = 0f;
    public static float yAxis = 0.3f;
    public static float zAxis = 0f;
    //public float BPM = 90f;
    public  float beatCD = 60f / 128f; //seconds per beat given 90 bpm
    public float noteSpeed = 20f;

    public float laneLength = 1000f;


    // Start is called before the first frame update
    void Start()
    {
        createNotes();
    }

    void createNotes()
    {


        // BPS = BMP/60
        //seconds/ beat
        // s = 20 units/second
        // s = d /t
        // d = s * t
        // 20 * beatCD;

        float beatDistance = noteSpeed * beatCD;

//         float BPS = BPM / 60;

        // 
        //

        //int randNum = (int)UnityEngine.Random.Range(2, max);
        //int randMultiplier = (int)UnityEngine.Random.Range(3, 5);

        int colourGen = (int)UnityEngine.Random.Range(0, 3) + 1;


        int randNumBEATS;// = (int)UnityEngine.Random.Range(0, 4) + 1;
        float spacer;// = (float) randNumBEATS * beatDistance;
        

        Boolean end = false;
        float totalDistance = 0;

        int test = 0;

        while (!end && test < 100)
        {
            randNumBEATS = (int)UnityEngine.Random.Range(1, 4) + 1;
            spacer = beatDistance / 2; //randNumBEATS;
            totalDistance += spacer;


            if ((spacer) - zAxis > laneLength)
            {
                end = true;
            }
            if (colourGen == 1)
            {
                Instantiate(redNote, new Vector3(xAxis + 2, yAxis, zAxis + totalDistance), Quaternion.identity);
                // spacer += randNum + randMultiplier;
                totalDistance += spacer;
                UnityEngine.Debug.Log("Red Beat");
                test++;
            }

            if (colourGen == 2)
            {
                Instantiate(blueNote, new Vector3(xAxis, yAxis, zAxis + totalDistance), Quaternion.identity);
                //spacer += randNum + randMultiplier;
                totalDistance += spacer;

                UnityEngine.Debug.Log("Blue Beat");
                test++;
            }

            if (colourGen == 3)
            {

                Instantiate(greenNote, new Vector3(xAxis - 2, yAxis, zAxis + totalDistance), Quaternion.identity);
                //spacer += randNum + randMultiplier;
                totalDistance += spacer;

                UnityEngine.Debug.Log("Green Beat");
                test++;
            }

       
            //randMultiplier = (int)UnityEngine.Random.Range(0, 8);
            colourGen = (int)UnityEngine.Random.Range(0, 3) + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
