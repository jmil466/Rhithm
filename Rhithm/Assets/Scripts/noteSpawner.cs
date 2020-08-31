using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class noteSpawner : MonoBehaviour
{
    //public float BPM = 90f;
    public  float secsPerBeat = 60f / 165f ;

    public float noteSpeed = 20f;

    public float difficultyMultiplier = 4; // Adjusts the Spawn Rate, default is 2

    // Position of Note Spawns
    public Vector3[] noteSpawnPositions; // Array for spawn positions of notes
    public Vector3 noteOneSpawn = new Vector3(1.025f, 0.3f, 43f); // Spawn Position of Note One
    public Vector3 noteTwoSpawn = new Vector3(0f, 0.3f, 43f); // Spawn Position of Note Two
    public Vector3 noteThreeSpawn = new Vector3(-1.025f, 0.3f, 43f); // Spawn Position of Note Three

    // Note Objects
    public GameObject noteOne; // Note One Prefab
    public GameObject noteTwo; // Note Two Prefab
    public GameObject noteThree; // Note Three Prefab
    public GameObject obstacle; // Obstacle Game Object
    private bool end;

    // Start is called before the first frame update
    void Start()
    {
        noteSpawnPositions = new[] { noteOneSpawn, noteTwoSpawn, noteThreeSpawn };
        StartCoroutine(WaitForBPM());
    }
    IEnumerator WaitForBPM()
    {
        while (!end) // change this to "Hey while theres more than X seconds of song left, keep spawning
        {

            yield return new WaitForSeconds(secsPerBeat / difficultyMultiplier);
            
            float randomNum = UnityEngine.Random.Range(0.0f, 1.0f);

            if (randomNum >= 0 && randomNum < 0.29)
            {
                Instantiate(noteOne, noteSpawnPositions[0], Quaternion.identity);
            }
            else if (randomNum >= 0.29 && randomNum < 0.58)
            { // Spawns Cube 2
                Instantiate(noteTwo, noteSpawnPositions[1], Quaternion.identity);
            }
            else if (randomNum >= 0.58 && randomNum < 0.87)
            { // Spawns Cube 3
                Instantiate(noteThree, noteSpawnPositions[2], Quaternion.identity);
            }
            else if (randomNum >= 0.87 && randomNum < 0.95)
            { // Spawns Damage Cube/combo breaker cube
                int index = UnityEngine.Random.Range(0, noteSpawnPositions.Length);
                Instantiate(obstacle, noteSpawnPositions[index], Quaternion.identity);
            }

        }


    }
}