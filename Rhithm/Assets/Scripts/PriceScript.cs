using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine.EventSystems;

public class PriceScript : MonoBehaviour
{
    public Text currencyText;
    public GameObject insufficientCoins;
    public GameObject[] items;
    public ColorBlock colors;

    public GameObject Items;
    private Button itemButton;
    private Text itemButtonText;
    public ShopScript shopScript;
    private string playerPrefabLocation;
    private ItemScript itemScript;

    void Start()
    {
        items = shopScript.getShopItems();
        Debug.Log("Running Start() of PriceScript...Num of items: " + items.Length);
    }

    public void OnClickItemButton()
    {
        itemButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>(); //get the Button component
        itemButtonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>(); //get the Text component
        itemScript = itemButton.GetComponentInParent<ItemScript>();

        int currency = PlayerPrefs.GetInt("Coins");
        int price = itemScript.itemPrice;

        Debug.Log("coins: " + currency);
        Debug.Log("price: " + price);

        if (itemButtonText.text == "Equip")
        {
            Debug.Log("Executing EquipItem()");
            EquipItem();
        }
        else if ((currency >= price) && (itemButtonText.text == ("$" + price.ToString())))
        {
            currency -= price;
            PlayerPrefs.SetInt("Coins", currency);
            currencyText.text = currency.ToString();
            PurchaseItem();
        }
        else if ((currency < price) && (itemButtonText.text == ("$" + price.ToString())))
        {
            insufficientCoins.SetActive(true);
        }
    }

    protected void PurchaseItem()
    {
        itemButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>(); //get the Button component
        itemButtonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>(); //get the Text component of the clicked button
        itemScript = itemButton.GetComponentInParent<ItemScript>();

        string itemName = itemScript.playerPrefabName;
        string itemPurchased = itemName + "Purchased";
        PlayerPrefs.SetInt(itemPurchased, 1); //purchases the item 0-false, 1-true
        itemScript.SetPurchased(true);

        colors = itemButton.colors;
        colors.normalColor = new Color32(75, 75, 75, 255);
        itemButtonText.color = new Color32(255, 255, 255, 255);
        itemButtonText.text = "Equip";
    }

    protected void EquipItem()
    {
        ColorBlock colors;
        string itemName;
        string itemEquipped;

        //this loop checks if an item is already equipped by checking the Text of the items corresponding button
        foreach (GameObject item in items)
        {
            Button anItemButton = item.transform.Find("PriceButton").GetComponent<Button>();
            Text anItemButtonText = item.transform.Find("PriceButton").GetComponentInChildren<Text>();
            itemScript = item.GetComponent<ItemScript>();

            if (itemScript.IsEquipped())
            {
                itemName = itemScript.playerPrefabName;
                Debug.Log("Previously equipped: " + itemScript.playerPrefabName);
                itemEquipped = itemName + "Equipped";

                PlayerPrefs.SetInt(itemEquipped, 0); //unequip the item 0-false, 1-true
                itemScript.SetEquipped(false);
                anItemButton.interactable = true;

                anItemButtonText.text = "Equip";
                anItemButtonText.color = new Color32(255, 255, 255, 255);

                colors = anItemButton.colors;
                colors.normalColor = new Color32(75, 75, 75, 255);
                anItemButton.colors = colors;
            }
        }

        itemButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>(); //get the Button component of the clicked button
        itemButtonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>(); //get the Text component of the clicked button
        itemScript = itemButton.GetComponentInParent<ItemScript>();

        playerPrefabLocation = itemButton.GetComponentInParent<ItemScript>().GetPrefabLocation();

        itemName = itemScript.playerPrefabName;
        itemEquipped = itemName + "Equipped";

        Debug.Log("Now equipping: " + itemName);
        PlayerPrefs.SetInt(itemEquipped, 1); //equips the item 0-false, 1-true
        itemScript.SetEquipped(true);
        itemButton.interactable = false;

        colors = itemButton.colors;
        colors.normalColor = new Color32(185, 185, 185, 255);
        itemButtonText.color = new Color32(75, 75, 75, 255);
        itemButtonText.text = "Equipped";
    }

    public void AssignItemComponents()
    {
        itemButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>(); //get the Button component when a button is clicked
        itemButtonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>(); //get the Text component when a button is clicked
        itemScript = itemButton.GetComponentInParent<ItemScript>(); //get the ItemScript component from the Parent gameObject (Item)
    }
}