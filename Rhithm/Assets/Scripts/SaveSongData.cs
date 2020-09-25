using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSongData : MonoBehaviour
{

    private SongObjectScript song;
    private string songName;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            song = FindObjectOfType<SongObjectScript>();
            songName = song.GetSongName();
        }
        catch (System.Exception e)
        { // Catch for when song doesn't load, spawn objects with no sound (testing purposes only)

            songName = "test";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveHighScore(int highScore)
    {
        string songSaveName = songName + "_highscore";
        PlayerPrefs.SetInt(songSaveName, highScore);
        Debug.Log(PlayerPrefs.GetInt(songSaveName));
    }

    public void savePerfectScore()
    {
        string perfectScoreSaveName = songName + "_perfectScore";
        PlayerPrefs.SetString(perfectScoreSaveName, "true");
        Debug.Log(PlayerPrefs.GetString(perfectScoreSaveName));
    }


}
