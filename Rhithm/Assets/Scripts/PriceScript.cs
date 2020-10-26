using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine.EventSystems;

public class PriceScript : MonoBehaviour
{
    //public Button selectedButton;
    //public Button otherButton1;
    //public Button otherButton2;
    //public Button otherButton3;
    //public Button otherButton4;
    //public Button otherButton5;
    //public Button otherButton6;
    //public Text priceText;
    public Text currencyText;
    public GameObject insufficientCoins;
    //maybe unnecessary
    //private bool isBought = false;
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

        //priceText = selectedButton.GetComponentInChildren<Text>();
        //Debug.Log(priceText);

        //if (priceText.text == "Equip")
        //{
        //    EquipItem();
        //}
        //else if (int.Parse(currencyText.text) >= int.Parse(priceText.text))
        //{
        //    ItemBought();
        //}
        //else if (int.Parse(currencyText.text) < int.Parse(priceText.text))
        //{
        //    insufficientCoins.SetActive(true);
        //}
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
            //currency - price;
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

        //selectedButton.interactable = false;
        //isBought = true;
        colors = itemButton.colors;
        //priceText = selectedButton.GetComponentInChildren<Text>();
        //Make button lighter and text darker than before bought but not as much as when Equipped
        colors.normalColor = new Color32(115, 115, 115, 255);
        itemButtonText.color = new Color32(85, 85, 85, 255);
        itemButtonText.text = "Equip";
        //otherText1.color = new Color32(65, 65, 65, 255);
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
        //Instantiate(Resources.Load<GameObject>(playerPrefabLocation), Items.transform);

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
        //set player == item
            
        //if isBought loop inside for loop
        //foreach (GameObject item in items)
        //{
        //    Button otherButton = item.transform.Find("PriceButton").GetComponent<Button>();
        //    Text otherText = item.transform.Find("PriceButton").GetComponentInChildren<Text>();

        //    if (otherText.text == "Equipped")
        //    {
        //        Debug.Log(otherText.text);
        //        otherText.text = "Equip";
        //        otherText.color = new Color32(255, 255, 255, 255);

        //        colors = otherButton.colors;
        //        colors.normalColor = new Color32(75, 75, 75, 255);
        //        otherButton.colors = colors;
        //    }
        //}

        /*
        for (int i = 0; i < items.Length; i++)
        {
            //private Text otherText = items[i].GameObject.Transform.Find("PriceButton").GetComponentInChildren<Text>();
            //private Button otherButton = items[i].GameObject.Transform.Find("PriceButton");

            private Button otherButton = items[i].GameObject.FindGameObjectsWithTag("PriceButton");
            private Text otherText = otherButton.GetComponentInChildren<Text>();

            if (otherText.text == "Equipped")
            {
                otherText.text = "Equip";
                otherText.color = new Color32(255, 255, 255, 255);

                ColorBlock colors = otherButton.colors;
                colors.normalColor = new Color32(75, 75, 75, 255);
                otherButton.colors = colors;
            }
        }
        /*
        if (isBought == true)
        {

        }
        */
    }

    public void AssignItemComponents()
    {
        itemButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>(); //get the Button component when a button is clicked
        itemButtonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>(); //get the Text component when a button is clicked
        itemScript = itemButton.GetComponentInParent<ItemScript>(); //get the ItemScript component from the Parent gameObject (Item)
    }
}