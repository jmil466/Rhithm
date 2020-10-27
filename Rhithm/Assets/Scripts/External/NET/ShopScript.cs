using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    private GameObject[] items;
    public GameObject insufficientCoins;
    public Text userCurrencyText;
    private int userCoins;
    public GameObject itemSect; 

    void Awake()
    {
        //PlayerPrefs.SetInt("Coins", 999);

        //PlayerPrefs.SetInt("PlayerCubeWhitePurchased", 0);
        //PlayerPrefs.SetInt("PlayerCubeWhiteEquipped", 0);

        PlayerPrefs.SetInt("PlayerCubeRedPurchased", 0);
        PlayerPrefs.SetInt("PlayerCubeRedEquipped", 0);

        userCoins = PlayerPrefs.GetInt("Coins");
        SetShop();
    }

    public void SetShop()
    {
        userCurrencyText.text = "$" + PlayerPrefs.GetInt("Coins").ToString(); //Get user coins

        items = GameObject.FindGameObjectsWithTag("Item"); //Find all items in the shop
        Debug.Log("Running SetShop() of ShopScript... Num of items = " + items.Length);

        ItemScript itemScript; //ItemScript for an item in the shop
        Button itemButton; //Button component of corresponding item in the shop
        Text itemButtonText; //Text component of corresponding item in the shop (Text can show the price of item, equip or equipped)
        ColorBlock colors; //ColorBlock for modifiying Text

        //loop through each item in the shop and set up whether an item has been purchased on an item is already equipped from previous visit
        foreach (GameObject item in items)
        {
            itemScript = item.GetComponent<ItemScript>(); //Assign
            itemButton = item.GetComponentInChildren<Button>(); //Assign
            itemButtonText = item.transform.Find("PriceButton").GetComponentInChildren<Text>(); //Assign

            string itemName = itemScript.playerPrefabName; //Get the item name
            string itemPurchased = itemName + "Purchased"; //The Key for PlayerPrefabs(Key, Value), a different key for each item purchased
            string itemEquipped = itemName + "Equipped";//The Key for PlayerPrefabs(Key,Value), a different key for each item equipped/unequipped
            //The Value of PlayerPrefabs(Key,Value) in this part can either only be 1 (true/purchased/equipped) or 0 (false/not purchased/unequipped)

            //This part is only applicable to the user very first opening of the game
            if (itemName.Equals("PlayerCubeWhite")) //The first playable player model
            {
                if (!itemScript.IsPurchased()) //If the item has not been purchased (Auto-purchase it for the user)
                {
                    PlayerPrefs.SetInt(itemPurchased, 1); //Save purchase
                    itemScript.SetPurchased(true);
                    PlayerPrefs.SetInt(itemEquipped, 1); //Auto-equip and save equipped state
                    itemScript.SetEquipped(true);
                }
            }

            if (itemScript.IsPurchased()) //If the item has been purchased
            {
                if (itemScript.IsEquipped()) //If the item is equipped from previous visit
                {
                    itemButton.interactable = false;
                    colors = itemButton.colors;
                    colors.normalColor = new Color32(185, 185, 185, 255);
                    itemButtonText.color = new Color32(75, 75, 75, 255);
                    itemButtonText.text = "Equipped";
                    Instantiate(Resources.Load<GameObject>(itemScript.GetPrefabLocation()), itemSect.transform); //load the player model
                }
                else //If the item is NOT equipped from previous visit
                {
                    itemButton.interactable = true;
                    colors = itemButton.colors;
                    colors.normalColor = new Color32(115, 115, 115, 255);
                    itemButtonText.color = new Color32(85, 85, 85, 255);
                    itemButtonText.text = "Equip";
                }
            } else //If the item has NOT been purchased
            {
                itemButtonText.text = "$" + itemScript.itemPrice.ToString();
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

    public int GetCoins()
    {
        return userCoins;
    }

    public GameObject[] getShopItems()
    {
        return items;
    }
}
