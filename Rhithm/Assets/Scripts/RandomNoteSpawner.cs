using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RandomNoteSpawner : MonoBehaviour
{

    public float BPM; // Beats per Minute
    public float secsPerBeat; // How long in seconds One Beat is
    public float difficultyMultiplier; // Adjusts the Spawn Rate, default is 1
    public bool firstSpawn = true; // Checks if this is the first iteration of the spawning while loop

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

    // SongObjectScript related
    public SongObjectScript song;
    public AudioSource currentSong; // The Song being played
    public float songLength; // The Length of the song being played
    public float currentPlayedTime = 0; // How Long the song has currently been playing for
    public float startDelay; // Delay of spawning for songs that don't start instantly 

    public Score score; // Score Object
    public ParticleSystem confetti; // Celebratory particle System
    public CompletionScript completionUI;
    public GameObject FinalScoreObject;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            song = findSong();
            BPM = song.getBPM(); // Gets selected Song's BPM
            Debug.Log(BPM);
            songLength = song.getAudioLength(); // Gets the song's length in seconds
            Debug.Log(songLength);
            secsPerBeat = 60f / BPM; // Calculates Seconds per Beat
            noteSpawnPositions = new Vector3[] { noteOneSpawn, noteTwoSpawn, noteThreeSpawn };
            startDelay = song.getStartDelay();
            difficultyMultiplier = song.getDifficultyMultiplier();
            song.playAudio();
            StartCoroutine(SpawnNote()); // Starts spawning Method
        } catch (Exception e) { // Catch for when song doesn't load, spawn objects with no sound (testing purposes only)
            BPM = 60f;
            songLength = 60f;
            secsPerBeat = 60f / BPM; // Calculates Seconds per Beat
            noteSpawnPositions = new Vector3[] { noteOneSpawn, noteTwoSpawn, noteThreeSpawn };
            difficultyMultiplier = 4;
            StartCoroutine(SpawnNote()); // Starts spawning Method
        }

    }

    void Update()
    {
        currentPlayedTime += Time.deltaTime; // Ensures accurate timekeeping
    }

    public void createNote(GameObject note, Vector3 spawnPosition)
    {
        Instantiate(note, spawnPosition, Quaternion.identity);
    }

    private SongObjectScript findSong()
    {
        return (SongObjectScript)FindObjectOfType(typeof(SongObjectScript));
    }


    IEnumerator SpawnNote()
    {
        yield return new WaitForSeconds(startDelay);

        while (songLength - currentPlayedTime > 55f) // Stops spawning with 2.5s of song remaining
        {

            float randomNum = UnityEngine.Random.Range(0.0f, 1.0f);

            if (firstSpawn) // Ensures a note spawns on the first beat, rather than a gap or an obstacle
            {
                firstSpawn = false;
                
                if (randomNum >= 0 && randomNum < 0.33)
                {// Spawns Note 1
                    createNote(noteOne, noteSpawnPositions[0]);
                }
                else if (randomNum >= 0.33 && randomNum < 0.66)
                { // Spawns Note 2
                    createNote(noteTwo, noteSpawnPositions[1]);
                }
                else if (randomNum >= 0.66 && randomNum <= 1)
                { // Spawns Note 3
                    createNote(noteThree, noteSpawnPositions[2]);
                }
            } 

            else // Standard Spawning Method
            {
                yield return new WaitForSeconds(secsPerBeat / difficultyMultiplier);
                
                if (randomNum >= 0 && randomNum <= 0.25)
                { // Spawns Note 1
                    createNote(noteOne, noteSpawnPositions[0]);
                }
                else if (randomNum >= 0.30 && randomNum <= 0.55)
                { // Spawns Note 2
                    createNote(noteTwo, noteSpawnPositions[1]);
                }
                else if (randomNum >= 0.60 && randomNum <= 0.85)
                { // Spawns Note 3
                    createNote(noteThree, noteSpawnPositions[2]);
                }
                else if (randomNum >= 0.87 && randomNum < 0.95)
                { // Spawns Obstacle
                    int index = UnityEngine.Random.Range(0, noteSpawnPositions.Length);
                    Vector3 currPos = noteSpawnPositions[index];
                    //currPos.y += 0.7f; // Increases the spawn height so that the Obstacle is not in the ground.
                    createNote(obstacle, currPos);
                }
            }
        }

        yield return new WaitForSeconds(5.5f);

        if (score.getNoteMissed() == false) // Full Combo's reward
        {
            //Celebrate here
            confetti.Play(); // 
            Debug.Log("Woop");
        }

        score.calculateHighScore();
        Debug.Log(score.getHighScore().ToString());
        completionUI.displayCompletionUI();

        FinalScoreObject = GameObject.Find("FinalScoreObject");
        FinalScoreObject.transform.SetParent(null);
        DontDestroyOnLoad(FinalScoreObject);

        //if (score.getNoteMissed() == false) // Stops celebration
        //{
        //    yield return new WaitForSeconds(5f); // GIves time for celebration and to display UI
        //    confetti.Stop();
        //}

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("SongList"); //load main menu scene
    }
}