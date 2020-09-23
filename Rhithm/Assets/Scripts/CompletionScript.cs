using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletionScript : MonoBehaviour
{

    public GameObject completionUIObject;
    private bool uiVisible;
    private int highScoreValue;
    private int scoreValue;
    public Text highScoreText;
    public Text userScoreText;
    public Score score;
    public GameObject scoreUI;


    // Start is called before the first frame update
    void Start()
    { 
        completionUIObject.SetActive(false);
        uiVisible = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void displayCompletionUI()
    {
        scoreUI.SetActive(false);
        completionUIObject.SetActive(true);
        uiVisible = true;
        displayHighScore();
        displayUserScore();

    }


    public void displayHighScore()
    {
        highScoreValue = score.getHighScore();
        highScoreText.text = "High Score: " + highScoreValue.ToString();
    }

    public void displayUserScore()
    {
        scoreValue = score.getScore();
        userScoreText.text = "User Score: " + scoreValue;
    }

    public bool highScoreIsVisible()
    {
        if (uiVisible && highScoreText.IsActive())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool userScoreIsVisible()
    {


        if (uiVisible && userScoreText.IsActive())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int getScore()
    {
        return scoreValue;
    }

    public int getHighScore()
    {
        return highScoreValue;
    }
}

