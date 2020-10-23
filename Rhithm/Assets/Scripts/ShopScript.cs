using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    private GameObject[] items;
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

        foreach (GameObject item in items)
        {
            //Text itemPriceText = item.GetComponentInChildren<Text>();
            ItemScript itemScript = item.GetComponent<ItemScript>();
            string itemName = itemScript.playerPrefabName;

            string itemPurchased = itemName + "Purchased";
            string itemEquipped = itemName + "Equipped";

            PlayerPrefs.SetInt(itemPurchased, boolToInt(itemScript.isPurchased()));
            PlayerPrefs.SetInt(itemEquipped, boolToInt(itemScript.isEquipped()));

            if (itemScript.isEquipped())
            {
                PlayerPrefs.SetInt(itemName, boolToInt(itemScript.isEquipped()));
            }
        }
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickClose()
    {
        insufficientCoins.SetActive(false);
    }

    public int getCoins()
    {
        return userCoins;
    }

    public GameObject[] getShopItems()
    {
        return items;
    }

    public int boolToInt(bool value)
    {
        if (value)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public bool intToBool(int value)
    {
        if (value != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
