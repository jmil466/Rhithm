﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using System;
using Random = UnityEngine.Random;
using UnityEngine.Audio;

namespace Tests
{
    public class TestSuite
    {

        [Test]
        public void HighScoreComparisonGreater() // TDD For Highscore user story
        {

            Canvas score = MonoBehaviour.Instantiate(Resources.Load<Canvas>("Prefabs/ScoringUI"));
            var scoreScript = score.GetComponent<Score>();

            int highScore = scoreScript.getHighScore();
            int currentScore = highScore + 10;

            Assert.Greater(currentScore, highScore);

        }

        [Test]
        public void HighScoreComparisonLesser()
        {
            Canvas score = MonoBehaviour.Instantiate(Resources.Load<Canvas>("Prefabs/ScoringUI"));
            var scoreScript = score.GetComponent<Score>();

            int highScore = scoreScript.getHighScore();
            int currentScore = scoreScript.getScore();

            Assert.LessOrEqual(highScore, currentScore);
        }

        [Test]
        public void DisplayScores()
        {
            Canvas completionScreen = MonoBehaviour.Instantiate(Resources.Load<Canvas>("Prefabs/CompletionUI"));

            CompletionScript completionScript = completionScreen.GetComponent<CompletionScript>();

            completionScript.displayCompletionUI();

            Assert.IsTrue(completionScript.highScoreIsVisible());
            Assert.IsTrue(completionScript.userScoreIsVisible());

        }
        
        [Test]
        public void IncreaseSFXVolume()
        {
            GameObject settingsMenu = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SettingsMenu"));
            SettingsMenu settingsMenuScript = settingsMenu.GetComponent<SettingsMenu>();
            GameObject sfxVolObj = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SFXVolObj"));
            SFXVolObj sfxVolObjScript = sfxVolObj.GetComponent<SFXVolObj>();
            AudioMixer sfxMixer = MonoBehaviour.Instantiate(Resources.Load<AudioMixer>("Audio/SFXMixer"));

            float currentSfxVolValue = sfxVolObjScript.getSfxVolValue();
            float newSfxVolValue = Random.Range(currentSfxVolValue, 0.0f);

            settingsMenuScript.SetSFXVolume(newSfxVolValue);
            float value;
            sfxMixer.GetFloat("volume", out value);

            Assert.Greater(value, currentSfxVolValue);
        }

        [Test]
        public void DecreaseSFXVolume()
        {
            GameObject settingsMenu = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SettingsMenu"));
            SettingsMenu settingsMenuScript = settingsMenu.GetComponent<SettingsMenu>();
            GameObject sfxVolObj = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SFXVolObj"));
            SFXVolObj sfxVolObjScript = sfxVolObj.GetComponent<SFXVolObj>();
            AudioMixer sfxMixer = MonoBehaviour.Instantiate(Resources.Load<AudioMixer>("Audio/SFXMixer"));

            float currentSfxVolValue = sfxVolObjScript.getSfxVolValue();
            float newSfxVolValue = Random.Range(-40.0f, currentSfxVolValue);

            settingsMenuScript.SetSFXVolume(newSfxVolValue);
            float value;
            sfxMixer.GetFloat("volume", out value);

            Assert.Less(value, currentSfxVolValue);
        }

        [UnityTest] // Test to see if notes move when spawned
        public IEnumerator NoteMovementTest() // Unit Test Example by James
        {
            var root = new GameObject();
            root.AddComponent<Camera>();

            var Camera = root.GetComponent<Camera>();

            GameObject note1 = Resources.Load<GameObject>("Prefabs/Note1");
            GameObject note2 = Resources.Load<GameObject>("Prefabs/Note2");
            GameObject note3 = Resources.Load<GameObject>("Prefabs/Note3");
            note1 = GameObject.Instantiate(note1, new Vector3(-2, 0, 10), new Quaternion(0, 180, 0, 0));
            note2 = GameObject.Instantiate(note2, new Vector3(0, 0, 10), new Quaternion(0, 180, 0, 0));
            note3 = GameObject.Instantiate(note3, new Vector3(2, 0, 10), new Quaternion(0, 180, 0, 0));

            float initalZPos1 = note1.transform.position.z;
            float initalZPos2 = note2.transform.position.z;
            float initalZPos3 = note3.transform.position.z;

            yield return new WaitForSeconds(0.1f);

            Assert.GreaterOrEqual(note1.transform.position.z, initalZPos1);
            Assert.GreaterOrEqual(note2.transform.position.z, initalZPos2);
            Assert.GreaterOrEqual(note3.transform.position.z, initalZPos3);
            GameObject.Destroy(note1);
            GameObject.Destroy(note2);
            GameObject.Destroy(note3);
            GameObject.Destroy(root);
        }

        [UnityTest]
        public IEnumerator ObstacleSpawnTest() // Unit Test by James 
        {
            GameObject obstacle = Resources.Load<GameObject>("Prefabs/Spike");
            GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Spawner"));
            var spawnerScript = spawner.GetComponent<RandomNoteSpawner>();
           
            spawnerScript.createNote(obstacle, new Vector3(0, 0, 0));

            yield return new WaitForSeconds(0.1f);

            Assert.IsTrue(GameObject.FindWithTag("Obstacle"));


        }


        [UnityTest]
        public IEnumerator ObstacleCollisionTest() // Unit Test by James
        {

            GameObject player = Resources.Load<GameObject>("Prefabs/player");
            GameObject obstacle = Resources.Load<GameObject>("Prefabs/Spike");
            Canvas score = MonoBehaviour.Instantiate(Resources.Load<Canvas>("Prefabs/ScoringUI"));
            player = GameObject.Instantiate(player, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            obstacle = GameObject.Instantiate(obstacle, new Vector3(0, 0, 20), new Quaternion(0, 0, 0, 0));
            var scoreScript = score.GetComponent<Score>();

            var expectedNoteStreak = 0;
            var currentNoteStreak = 2;
            yield return new WaitForSeconds(1.2f);

            currentNoteStreak = scoreScript.getNoteStreak();

            Assert.AreEqual(currentNoteStreak, expectedNoteStreak);

        }

        [Test]
        public void muteGame()
        {

        }

        [Test]
        public IEnumerator previewSong() //Unit Test by Rafael (Testing to see if the right audio is playing and for 10 seconds)
        {
            AudioSource AbsenceAudioSource = Resources.Load<AudioSource>("Prefabs/AbsenceAudioSource");
            Canvas SongSelectionCanvas = Resources.Load<Canvas>("Prefabs/SongSelectionCanvas");

            AbsenceAudioSource = AudioSource.Instantiate(Resources.Load<AudioSource>("Prefabs/AbsenceAudioSource"));
            SongSelectionCanvas = Canvas.Instantiate(Resources.Load<Canvas>("Prefabs/SongSelectionCanvas"));

            SongSelectionScript songSelectionScript = SongSelectionCanvas.GetComponent<SongSelectionScript>();
            
            GameObject[] songPanels = songSelectionScript.songPanels;
            int counter = songSelectionScript.activePanelCounter;

            songPanels[counter].SetActive(false);

            counter = 1; //the panel where Absence should be showing and preview that song

            songPanels[counter].SetActive(true);

            songSelectionScript.onClickPreviewSong(); //play the song in that panel

            Assert.IsTrue(AbsenceAudioSource.isPlaying);

            yield return new WaitForSeconds(10f);

            Assert.IsFalse(AbsenceAudioSource.isPlaying); //audio should have stopped playing
        }
    }
}
