using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    //public float playerSpeed = 0.01f;
    private Vector3 currentPos;
    //public int score;
    //public Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        //scoreText.text = "Score: 0";
    }
    // Update is called once per frame
    void Update()
    {
        currentPos = gameObject.transform.position;


    }

}
