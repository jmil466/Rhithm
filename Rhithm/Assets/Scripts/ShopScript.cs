using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    //Tag shop items Item then use tag to store all items into array
    public Text currencyText;

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
