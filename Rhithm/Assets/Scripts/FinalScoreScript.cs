using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreScript : MonoBehaviour
{
    public int currentHighScore;
    public int userScore;
    public string songName;
    public string songKey;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("CompletionUI") != null)
        {
            CompletionScript completionScript = GameObject.Find("CompletionUI").GetComponent<CompletionScript>();
            SongObjectScript songObjectScript = (SongObjectScript)FindObjectOfType(typeof(SongObjectScript));

            currentHighScore = completionScript.getHighScore();
            userScore = completionScript.getUserScore();
            songName = songObjectScript.GetSongName();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
