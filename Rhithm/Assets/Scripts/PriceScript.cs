using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PriceScript : MonoBehaviour
{
    public Button selectedButton;
    public Text priceText;
    public Text currencyText;
    public GameObject insufficientCoins;

    public void PriceButton()
    {
        priceText = selectedButton.GetComponentInChildren<Text>();
        if (int.Parse(currencyText.text) >= int.Parse(priceText.text))
        {
            ItemBought();
        }
        else
        {
            insufficientCoins.SetActive(true);
        }
    }

    void ItemBought()
    {
        selectedButton.interactable = false;
        ColorBlock colors = selectedButton.colors;
        //priceText = selectedButton.GetComponentInChildren<Text>();
        colors.normalColor = new Color32(75, 75, 75, 255);
        priceText.color = new Color32(65, 65, 65, 255);
        //otherText1.color = new Color32(65, 65, 65, 255);
    }
}
