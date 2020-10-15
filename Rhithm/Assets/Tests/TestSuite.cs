using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using System;
using Random = UnityEngine.Random;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        public void muteGameTest()
        {
            Canvas songSelectionCanvas = Resources.Load<Canvas>("Prefabs/SongSelectionCanvas");
            songSelectionCanvas = Canvas.Instantiate(Resources.Load<Canvas>("Prefabs/SongSelectionCanvas"));

            SongSelectionScript songSelectionScript = songSelectionCanvas.GetComponent<SongSelectionScript>();
            songSelectionScript.FindSongs();

            AudioSource buttonClickSound = songSelectionScript.buttonClickSound;
            songSelectionScript.OnClickMute();
            AudioSource currentSongAudioSource = songSelectionScript.currentSong.GetComponent<AudioSource>();

            Assert.IsTrue(buttonClickSound.mute);
            Assert.IsTrue(currentSongAudioSource.mute);

            songSelectionScript.OnClickMute();

            Assert.IsFalse(buttonClickSound.mute);
            Assert.IsFalse(currentSongAudioSource.mute);
        }

        //[Test]
        //public void previewSongTest() //Unit Test by Rafael (Testing to see if the correct audio source is playing when previewing a song)
        //{
        //    AudioSource AudioSourceDemo = Resources.Load<AudioSource>("Prefabs/AudioSourceDemo");
        //    AudioSourceDemo = AudioSource.Instantiate(Resources.Load<AudioSource>("Prefabs/AudioSourceDemo"));

        //    Canvas songSelectionCanvas = Resources.Load<Canvas>("Prefabs/SongSelectionCanvas");
        //    songSelectionCanvas = Canvas.Instantiate(Resources.Load<Canvas>("Prefabs/SongSelectionCanvas"));

        //    SongSelectionScript songSelectionScript = songSelectionCanvas.GetComponent<SongSelectionScript>();
        //    songSelectionScript.SetSongPanels();

        //    songSelectionScript.onClickPreviewSong();

        //    Assert.IsTrue(AudioSourceDemo.isPlaying);
        //}

        [Test]
        public void previewSongTest() //Unit Test by Rafael (Testing to see if the correct audio source is playing when previewing a song)
        {
            Canvas songSelectionCanvas = Resources.Load<Canvas>("Prefabs/SongSelectionCanvas");
            songSelectionCanvas = Canvas.Instantiate(Resources.Load<Canvas>("Prefabs/SongSelectionCanvas"));

            SongSelectionScript songSelectionScript = songSelectionCanvas.GetComponent<SongSelectionScript>();
            songSelectionScript.FindSongs();

            GameObject[] songPanels = songSelectionScript.songs;

            int numOfPanels = songSelectionScript.numOfPanels; //get the number of songPanels in the canvas
            int randPanel = Random.Range(0, numOfPanels - 1); //get a random song panel
            int activePanel = songSelectionScript.activePanelCounter; //get the active song panel

            songPanels[activePanel].SetActive(false); //hide the current active song panel

            songSelectionScript.activePanelCounter = randPanel;
            activePanel = randPanel;

            songPanels[activePanel].SetActive(true);

            AudioSource audioSource = songPanels[activePanel].GetComponentInChildren<AudioSource>();

            songSelectionScript.onClickPreviewSong();

            Assert.IsTrue(audioSource.isPlaying);
        }

        //[Test]
        //public void playSongTest()
        //{
        //    Canvas songSelectionCanvas = Resources.Load<Canvas>("Prefabs/SongSelectionCanvas");
        //    songSelectionCanvas = Canvas.Instantiate(Resources.Load<Canvas>("Prefabs/SongSelectionCanvas"));

        //    SongSelectionScript songSelectionScript = songSelectionCanvas.GetComponent<SongSelectionScript>();
        //    songSelectionScript.SetSongPanels();

        //    GameObject[] songPanels = songSelectionScript.songPanels;

        //    int numOfPanels = songSelectionScript.numOfPanels; //get the number of songPanels in the canvas
        //    int randPanel = Random.Range(0, numOfPanels - 1); //get a random song panel
        //    int activePanel = songSelectionScript.activePanelCounter; //get the active song panel

        //    songPanels[activePanel].SetActive(false); //hide the current active song panel

        //    songSelectionScript.activePanelCounter = randPanel;
        //    activePanel = randPanel;

        //    songPanels[activePanel].SetActive(true);

        //    songSelectionScript.OnClickPlaySong();

        //    GameObject difficultyMenu = GameObject.Find("DifficultyMenu");

        //    Assert.IsTrue(difficultyMenu.activeSelf);

        //    string difficulty = "HARD";

        //    EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = difficulty;

        //    songSelectionScript.OnClickChooseDifficulty();
        //}

        [UnityTest]
        public IEnumerator longSwipeTestLeft() // Matt TDD 
        {
            GameObject player = Resources.Load<GameObject>("Prefabs/player");
            player = GameObject.Instantiate(player, new Vector3(2, 0, 0), new Quaternion(0, 0, 0, 0));

            var movementScript = player.GetComponent<SmoothMobileInput>();

            float swipeDelta = 100;

            movementScript.longSwipe(swipeDelta);

            //If firstTouch - endTouch = swipeDelta
            //If swipeDelta is positive, left swipe should be registered
            //If swipeDelta > longSwipeRange && player is at right most position (x: 2)
            //long swipe registered
            //player pos should now be (x: -2)

            float actualPlayerEndPos = player.transform.position.x;
            float expectedXPos = -2;

            yield return new WaitForSeconds(5.0f);

            if (movementScript.lerpComplete)
            {
                Assert.AreEqual(expectedXPos, actualPlayerEndPos);
            }
        }
    }
}
