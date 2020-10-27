using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    //public float playerSpeed = 0.01f;
    private Vector3 currentPos;
    //public int score;
    //public Text scoreText;


    // Start is called before the first frame update
    

    void Awake()
    {
        FindEquippedPlayer();
    }

    void Start()
    {
        //scoreText.text = "Score: 0";
    }
    // Update is called once per frame
    void Update()
    {
        currentPos = gameObject.transform.position;
        // Move Player Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentPos.x >= 0)
            {
                transform.Translate(-2, 0, 0);
                //Debug.Log("Position is now " + currentPos);

            }
        }
        // Move Player Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentPos.x <= 1)
            {
                transform.Translate(2, 0, 0);

                //Debug.Log("Position is now " + currentPos);
            }
        }
    }

    private bool IsShopVisited()
    {
        if (PlayerPrefs.GetInt("PlayerCubeWhitePurchased") == -1)
        {
            Debug.Log("Shop not visited yet.");
            return false; //not visited shop yet
        }
        else
        {
            Debug.Log("Shop already visited.");
            return true; //visited shop already
        }
    }

    private void FindEquippedPlayer()
    {
        GameObject[] playerModels = GameObject.FindGameObjectsWithTag("PlayerModel");
        Debug.Log("Num of player models: " + playerModels.Length);

        if (!IsShopVisited())
        {
            foreach (GameObject pM in playerModels)
            {
                if (pM.name == "PlayerCubeWhite")
                {
                    Debug.Log("Setting " + pM.name + " active...");
                    pM.SetActive(true);
                }
                else
                {
                    pM.SetActive(false);
                }
            }
        }
        else
        {
            foreach (GameObject pM in playerModels)
            {
                string equippedKey = pM.name + "Equipped";

                if (PlayerPrefs.GetInt(equippedKey) == 1)
                {
                    Debug.Log("Setting " + pM.name + " active...");
                    pM.SetActive(true);
                }
                else
                {
                    pM.SetActive(false);
                }
            }
        }
    }

   /* private void OnTriggerEnter(Collider other)
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


        //scoreText.text = "Score: " + score;
    }
    public void changeScore(string tag)
    {
        if (score > 0)
        {
            if (tag == "damage")
            {
                score++;
                //scoreText.text = "Score: " + score;
            }
            else if (tag == "Score")
            {
                score--;
                //scoreText.text = "Score: " + score;
            }
        }
    }*/
}
