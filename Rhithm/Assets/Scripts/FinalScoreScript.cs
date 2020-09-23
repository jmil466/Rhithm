using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreScript : MonoBehaviour
{
    public int currentHighScore;
    public int userScore;
    public string songName;

    // Start is called before the first frame update
    void Start()
    {
        CompletionScript completionScript = GameObject.Find("CompletionUI").GetComponent<CompletionScript>();
        SongObjectScript songObjectScript = GameObject.Find("SongObject").GetComponent<SongObjectScript>();

        currentHighScore = completionScript.getHighScore();
        userScore = completionScript.getUserScore();
        songName = songObjectScript.getSongName();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
