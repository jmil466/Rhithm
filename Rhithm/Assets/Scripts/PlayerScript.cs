using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    //public float playerSpeed = 0.01f;
    private Vector3 currentPos;
    public int score;
    public Text scoreText;
    //private Touch touch;
 

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
    }
    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if (MobileInput.Instance.SwipeLeft)
=======
        //currentPos = gameObject.transform.position;

        if (Mobile_Input.Instance.SwipeLeft)
>>>>>>> Stashed changes
        {
            Debug.Log("LEFT SWIPE STEP IN");

            if (currentPos.x >= 0)
            {
                transform.Translate(-2, 0, 0);
                currentPos = gameObject.transform.position;

                Debug.Log("Position is now " + currentPos);

            }
        }

<<<<<<< Updated upstream
        if (MobileInput.Instance.SwipeRight)
=======
        if (Mobile_Input.Instance.SwipeRight)
>>>>>>> Stashed changes
        {
            Debug.Log("RIGHT SWIPE STEP IN");

            if (currentPos.x <= 1)
            {
                transform.Translate(2, 0, 0);
                currentPos = gameObject.transform.position;

                Debug.Log("Position is now " + currentPos);
            }
        }


        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "damage" && score > 0)
        {
            score--;
        }
        else if (other.gameObject.tag == "Score")
        {
            score++;
        }
        Destroy(other.gameObject);


        scoreText.text = "Score: " + score;
    }
    public void changeScore(string tag)
    {
        if (score > 0)
        {
            if (tag == "damage")
            {
                score++;
                scoreText.text = "Score: " + score;
            }
            else if (tag == "Score")
            {
                score--;
                scoreText.text = "Score: " + score;
            }
        }
    }




}
