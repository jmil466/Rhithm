using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    //Tag shop items Item then use tag to store all items into array
    public GameObject[] items;
    //items = GameObject.FindGameObjectsWithTag("Item");
    public Text currencyText;

    void Start()
    {
        SetShop();
    }

    public void SetShop()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
