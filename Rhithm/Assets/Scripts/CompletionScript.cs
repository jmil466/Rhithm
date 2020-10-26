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
    public FinalScoreScript finalScoreScript;


    // Start is called before the first frame update
    void Start()
    {
        completionUIObject.SetActive(false);
        uiVisible = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        highScoreValue = 5;
    }

    public void displayCompletionUI()
    {
        scoreUI.SetActive(false);
        completionUIObject.SetActive(true);
        uiVisible = true;
        displayHighScore();
        displayUserScore();
        finalScoreScript.CalculateFinalScore();
    }


    public void displayHighScore()
    {
        highScoreValue = score.getHighScore();
        highScoreText.text = "High Score: " + highScoreValue.ToString();
    }

    public void displayUserScore()
    {
        scoreValue = score.getScore();
        userScoreText.text = "User Score: " + scoreValue.ToString();
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

    public int getHighScore()
    {
        return highScoreValue;
    }

    public int getUserScore()
    {
        return scoreValue;
    }
}

