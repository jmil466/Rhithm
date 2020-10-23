using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public GameObject[] items;
    public GameObject insufficientCoins;
    private int userCoins;

    void Start()
    {
        SetShop();

        userCoins = PlayerPrefs.GetInt("Coins");
    }

    public void SetShop()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Close()
    {
        insufficientCoins.SetActive(false);
    }

    public int getCoins()
    {
        return userCoins;
    }
}
