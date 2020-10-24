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
    public Text priceButtonText;
    public ShopScript shopScript;
    private string playerPrefabLocation;
    private ItemScript itemScript;

    void Start()
    {
        items = shopScript.getShopItems();
    }

    public void PriceButton()
    {
        priceButtonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>(); //get the Text component
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
        int currency = int.Parse(currencyText.text);
        int price = int.Parse(priceButtonText.text);

        if (priceButtonText.text == "Equip")
        {
            EquipItem();
        }
        else if (currency >= price)
        {
            //currency - price;
            ItemBought();
        }
        else if (currency < price)
        {
            insufficientCoins.SetActive(true);
        }
    }

    void ItemBought()
    {
        Button selectedButton = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Button>(); //get the Button component
        //selectedButton.interactable = false;
        //isBought = true;
        colors = selectedButton.colors;
        //priceText = selectedButton.GetComponentInChildren<Text>();
        //Make button lighter and text darker than before bought but not as much as when Equipped
        colors.normalColor = new Color32(115, 115, 115, 255);
        priceButtonText.color = new Color32(85, 85, 85, 255);
        priceButtonText.text = "Equip";
        //otherText1.color = new Color32(65, 65, 65, 255);
    }

    void EquipItem()
    {
        ColorBlock colors;
        string itemName;
        string itemEquipped;

        //this loop checks if an item is already equipped by checking the Text of the items corresponding button
        foreach (GameObject item in items)
        {
            Button aButton = item.transform.Find("PriceButton").GetComponent<Button>();
            Text aButtonText = item.transform.Find("PriceButton").GetComponentInChildren<Text>();

            itemScript = item.GetComponent<ItemScript>();
            
            if (itemScript.isEquipped())
            {
                itemName = itemScript.playerPrefabName;
                itemEquipped = itemName + "Equipped";

                PlayerPrefs.SetInt(itemEquipped, 0); //unequip the item 0-false, 1-true
                itemScript.setEquipped(false);
                aButton.interactable = true;

                Debug.Log(aButtonText.text);
                aButtonText.text = "Equip";
                aButtonText.color = new Color32(255, 255, 255, 255);

                colors = aButton.colors;
                colors.normalColor = new Color32(75, 75, 75, 255);
                aButton.colors = colors;
            }
        }

        Button selectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>(); //get the Button component of the clicked button
        Text clickedButtonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>(); //get the Text component of the clicked button
   
        itemScript = selectedButton.GetComponentInParent<ItemScript>();

        playerPrefabLocation = selectedButton.GetComponentInParent<ItemScript>().getPrefabLocation();
        //Instantiate(Resources.Load<GameObject>(playerPrefabLocation), Items.transform);

        itemName = itemScript.playerPrefabName;
        itemEquipped = itemName + "Equipped";

        PlayerPrefs.SetInt(itemEquipped, 1); //equips the item 0-false, 1-true
        itemScript.setEquipped(true);
        selectedButton.interactable = false;

        colors = selectedButton.colors;
        colors.normalColor = new Color32(185, 185, 185, 255);
        clickedButtonText.color = new Color32(75, 75, 75, 255);
        clickedButtonText.text = "Equipped";
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
}