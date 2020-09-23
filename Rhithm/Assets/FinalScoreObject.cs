using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreObject : MonoBehaviour
{
    public int currentHighScore;
    public int finalScore;
    public GameObject songObject;
    public string songName;

    // Start is called before the first frame update
    void Start()
    {
        CompletionScript completionScript = GameObject.Find("CompletionUI").GetComponent<CompletionScript>();
        songObject = GameObject.Find("SongObject");

        songName = songObject.GetComponent<SongObjectScript>().getSongName();
        currentHighScore = completionScript.getHighScore();
        finalScore = completionScript.getScore();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
