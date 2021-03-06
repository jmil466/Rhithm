﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteGenerator : MonoBehaviour
{
    public List<Transform> plotPoints;
    private Material highlightMaterial;
    public int displayWindowSize = 300;
    public float BPM; // Beats per Minute
    public float secondsPerBeat; // How long in seconds One Beat is
    public float difficultyMultiplier; // Adjusts the Spawn Rate, default is 1

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
    public float songLength; // The Length of the song being played
    public float startDelay; // Delay of spawning for songs that don't start instantly 
    private float elapsedTime = 0;
    private float previousTime;

    // Score Related
    public Score score; // Score Object
    public ParticleSystem confetti; // Celebratory particle System
    public CompletionScript completionUI;
    public GameObject FinalScoreObject;
    public SaveSongData songData;
    private bool confettiCalled = false;
    private bool ending = false;
    private bool endingCalled;

    //SpectrumFlux data
    private float largestFlux = 0f;
    private float obstacleFlux;
    private float noteOneFlux;
    private float noteTwoFlux;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            song = findSong(); // Finds SongObject in scene
            BPM = song.GetBPM(); // Gets selected Song's BPM
            songLength = song.GetAudioLength(); // Gets the song's length in seconds
            secondsPerBeat = 60f / BPM; // Calculates Seconds per Beat
            noteSpawnPositions = new Vector3[] { noteOneSpawn, noteTwoSpawn, noteThreeSpawn };
            startDelay = song.GetStartDelay();
            difficultyMultiplier = song.GetDifficultyMultiplier();
            Debug.Log("START A");
        }
        catch (System.Exception e)
        { // Catch for when song doesn't load, spawn objects with no sound (testing purposes only)
            BPM = 60f;
            songLength = 60f;
            secondsPerBeat = 60f / BPM; // Calculates Seconds per Beat
            noteSpawnPositions = new Vector3[] { noteOneSpawn, noteTwoSpawn, noteThreeSpawn };
            difficultyMultiplier = 4;
            Debug.Log("START B");
        }

        plotPoints = new List<Transform>();

        float localWidth = transform.Find("Point/BasePoint").localScale.x;
        // -n/2...0...n/2
        for (int i = 0; i < displayWindowSize; i++)
        {
            //Instantiate point
            Transform t = (Instantiate(Resources.Load("Prefabs/Point"), transform) as GameObject).transform;

            // Set position
            float pointX = (displayWindowSize / 2) * -1 * localWidth + i * localWidth;
            t.localPosition = new Vector3(pointX, t.localPosition.y, t.localPosition.z);

            plotPoints.Add(t);
        }


    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public void updatePlot(List<SpectralFluxInfo> pointInfo, int curIndex = -1)
    {
        if (plotPoints.Count < displayWindowSize - 1)
            return;

        int numPlotted = 0;
        int windowStart = 0;
        int windowEnd = 0;

        if (curIndex > 0)
        {
            windowStart = Mathf.Max(0, curIndex - displayWindowSize / 2);
            windowEnd = Mathf.Min(curIndex + displayWindowSize / 2, pointInfo.Count - 1);
        }
        else
        {
            windowStart = Mathf.Max(0, pointInfo.Count - displayWindowSize - 1);
            windowEnd = Mathf.Min(windowStart + displayWindowSize, pointInfo.Count);
        }


        for (int i = windowStart; i < windowEnd; i++)
        {

            int plotIndex = numPlotted;
            numPlotted++;

            if (pointInfo[i].spectralFlux > largestFlux && (pointInfo[i].spectralFlux / largestFlux) >= 4) // If currentFlux is larger than existing largestflux, AND if the currentFlux is 4x larger than the current largestFlux
            {
                largestFlux = pointInfo[i].spectralFlux;
                calculateFlux(largestFlux);

                //Debug.Log("BIGGER " + largestFlux);

            }
            else if (largestFlux / pointInfo[i].spectralFlux >= 10) // If largestFlux is 10x larger than the currentFlux
            {
                largestFlux = pointInfo[i].spectralFlux;
                calculateFlux(largestFlux);
                //Debug.Log("SMALLER " + largestFlux);
            }

            if (elapsedTime < songLength + 2f) // Determines if song is ending
            {
                if (elapsedTime > startDelay) // Determines if starting Delay has been completed
                {
                    if ((int)(elapsedTime * 100) % ((int)(100 * secondsPerBeat / 4)) == 0 && elapsedTime != previousTime && (elapsedTime - previousTime > secondsPerBeat / difficultyMultiplier) && (songLength - elapsedTime > 2.5f)) // To prevent multiple notes spawn for each 'beat', as well as stopping spawning prior to audio end
                    {
                        previousTime = elapsedTime;
                        spawnNote(pointInfo[i].spectralFlux);
                    }

                }
            }
            else
            {
                ending = true;
                break;
            }


        }

        if(ending && endingCalled == false)
        {
            endingCalled = true;
            EndGame();
        }
        

    }

    public void EndGame()
    {

        if (score.getNoteMissed() == false && confettiCalled == false) // Full Combo's reward
        {
            confettiCalled = true;
            //Celebrate here
            confetti.Play();
            Debug.Log("Perfect score received.");
            songData.savePerfectScore();
        }

        score.calculateHighScore();
        Debug.Log(score.getHighScore().ToString());
        completionUI.displayCompletionUI();
        songData.CalculateCoins();

        StartCoroutine(WaitToEnd(5));

        
    }


    public void spawnNote(float currentFlux)
    {

        if (currentFlux == 0)
        {
            setNotePosition(noteOne, noteSpawnPositions[0]);
        }
        else if (currentFlux > noteOneFlux && currentFlux <= obstacleFlux)
        {
            int index = UnityEngine.Random.Range(0, noteSpawnPositions.Length); // Selects lane for Obstacle to be spawned in
            setNotePosition(obstacle, noteSpawnPositions[index]);
        }
        else if (currentFlux > obstacleFlux && currentFlux < noteTwoFlux * 1.25)
        {
            setNotePosition(noteTwo, noteSpawnPositions[1]);
        }
        else if (currentFlux > noteTwoFlux * 1.25)
        {
            setNotePosition(noteThree, noteSpawnPositions[2]);
        }

    }

    public void setNotePosition(GameObject note, Vector3 SpawnPosition)
    {
        Instantiate(note, SpawnPosition, Quaternion.identity);
    }

    public void calculateFlux(float largestFlux)
    {
        float fluxDiv = largestFlux / 5;

        noteOneFlux = fluxDiv * 2;
        obstacleFlux = fluxDiv * 3;
        noteTwoFlux = fluxDiv * 4;
    }

    


    private SongObjectScript findSong()
    {
        return (SongObjectScript)FindObjectOfType(typeof(SongObjectScript));
    }

    private IEnumerator WaitToEnd(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        FinalScoreObject = GameObject.Find("FinalScoreObject");
        FinalScoreObject.transform.SetParent(null);
        DontDestroyOnLoad(FinalScoreObject);

        GameObject songGameObject = GameObject.FindGameObjectWithTag("Song");
        Destroy(songGameObject);

        SceneManager.LoadScene("SongList");
    }




}
