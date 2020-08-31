using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGraphics : MonoBehaviour
{
    public int qualityLevel;
    public Button selectedButton;
    public Button otherButton1;
    public Button otherButton2;
    public Text selectedText;
    public Text otherText1;
    public Text otherText2;

    public void SelectedGraphics()
    {
        if (qualityLevel == 0)
        {
            QualitySettings.SetQualityLevel(qualityLevel);

            TurnButtonLight();
            TurnOtherButtonsDark();
        }
        else if (qualityLevel == 1)
        {
            QualitySettings.SetQualityLevel(qualityLevel);

            TurnButtonLight();
            TurnOtherButtonsDark();
        }
        else
        {
            QualitySettings.SetQualityLevel(qualityLevel);

            TurnButtonLight();
            TurnOtherButtonsDark();
        }
    }

    void TurnButtonLight()
    {
        ColorBlock colors = selectedButton.colors;
        colors.normalColor = new Color32(185, 185, 185, 255);
        selectedButton.colors = colors;
        selectedText.color = new Color32(75, 75, 75, 255);
    }

    void TurnOtherButtonsDark()
    {
        ColorBlock colors = otherButton1.colors;
        colors.normalColor = new Color32(75, 75, 75, 255);
        otherButton1.colors = colors;
        otherButton2.colors = colors;
        otherText1.color = new Color32(255, 255, 255, 255);
        otherText2.color = new Color32(255, 255, 255, 255);
    }

    
}