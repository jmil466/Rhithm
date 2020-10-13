using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public GameObject[] items;
    public GameObject insufficientCoins;

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

    public void Close()
    {
        insufficientCoins.SetActive(false);
    }
}
