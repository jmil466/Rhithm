using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PriceScript : MonoBehaviour
{
    public Button selectedButton;
    public Button otherButton1;
    public Button otherButton2;
    public Button otherButton3;
    public Button otherButton4;
    public Button otherButton5;
    public Button otherButton6;
    public Text priceText;
    public Text currencyText;
    public GameObject insufficientCoins;
    //maybe unnecessary
    //private bool isBought = false;
    public GameObject[] items;

    public void PriceButton()
    {
        priceText = selectedButton.GetComponentInChildren<Text>();
        if (priceText.text == "Equip")
        {
            EquipItem();
        }
        else if (int.Parse(currencyText.text) >= int.Parse(priceText.text))
        {
            ItemBought();
        }
        else if (int.Parse(currencyText.text) < int.Parse(priceText.text))
        {
            insufficientCoins.SetActive(true);
        }
    }

    void ItemBought()
    {
        //selectedButton.interactable = false;
        //isBought = true;
        ColorBlock colors = selectedButton.colors;
        //priceText = selectedButton.GetComponentInChildren<Text>();
        colors.normalColor = new Color32(75, 75, 75, 255);
        priceText.color = new Color32(65, 65, 65, 255);
        priceText.text = "Equip";
        //otherText1.color = new Color32(65, 65, 65, 255);
    }
    
    void EquipItem()
    {
        ColorBlock colors = selectedButton.colors;
        colors.normalColor = new Color32(185, 185, 185, 255);
        priceText.color = new Color32(75, 75, 75, 255);
        priceText.text = "Equipped";
        //set player == item

        items = GameObject.FindGameObjectsWithTag("Item");
        //if isBought loop inside for loop
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