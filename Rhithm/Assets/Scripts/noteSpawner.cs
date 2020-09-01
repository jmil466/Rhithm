using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class noteSpawner : MonoBehaviour
{
    public float BPM;
    public float secsPerBeat;
    public float difficultyMultiplier; // Adjusts the Spawn Rate, default is 1
    public bool firstSpawn = true;

    // Position of Note Spawns
    public Vector3[] noteSpawnPositions; // Array for spawn positions of notes
    public Vector3 noteOneSpawn; // Spawn Position of Note One
    public Vector3 noteTwoSpawn; // Spawn Position of Note Two
    public Vector3 noteThreeSpawn; // Spawn Position of Note Three

    // Note Objects
    public GameObject noteOne; // Note One Prefab
    public GameObject noteTwo; // Note Two Prefab
    public GameObject noteThree; // Note Three Prefab
    public GameObject obstacle; // Obstacle Game Object
    private bool end;

    // Start is called before the first frame update
    void Start()
    {
        secsPerBeat = 60f / BPM;
        Debug.Log(secsPerBeat);
        noteSpawnPositions = new Vector3[] { noteOneSpawn, noteTwoSpawn, noteThreeSpawn };
        StartCoroutine(WaitForBPM());
    }
    IEnumerator WaitForBPM()
    {
        while (!end) // change this to "Hey while theres more than X seconds of song left, keep spawning
        {

            if (firstSpawn == false)
            {
                yield return new WaitForSeconds(secsPerBeat / difficultyMultiplier);
            }
            
            float randomNum = UnityEngine.Random.Range(0.0f, 1.0f);

            if (randomNum >= 0 && randomNum <= 0.25)
            {
                Instantiate(noteOne, noteSpawnPositions[0], Quaternion.identity);
            }
            else if (randomNum >= 0.30 && randomNum <= 0.55)
            { // Spawns Cube 2
                Instantiate(noteTwo, noteSpawnPositions[1], Quaternion.identity);
            }
            else if (randomNum >= 0.60 && randomNum <= 0.85)
            { // Spawns Cube 3
                Instantiate(noteThree, noteSpawnPositions[2], Quaternion.identity);
            }
            else if (randomNum >= 0.87 && randomNum < 0.95) 
            { // Spawns Damage Cube/combo breaker cube
                int index = UnityEngine.Random.Range(0, noteSpawnPositions.Length);
                Instantiate(obstacle, noteSpawnPositions[index], Quaternion.identity);
            }

            if (firstSpawn)
            {
                firstSpawn = false;
            }

        }


    }
}

