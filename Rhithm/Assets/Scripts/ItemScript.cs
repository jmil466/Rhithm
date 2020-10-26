using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private string playerPrefabLocation;
    public string playerPrefabName;

    public int itemPrice;
    public bool equipped;
    public bool purchased;
    
    void Start()
    {

    }
    
    public string GetPrefabLocation()
    {
        playerPrefabLocation = "Prefabs/PlayerPrefabs/" + playerPrefabName;
        Debug.Log(playerPrefabLocation);
        return playerPrefabLocation;
    }

    public bool IsEquipped()
    {
        string key = playerPrefabName + "Equipped";
        bool result = IntToBool(PlayerPrefs.GetInt(key));
        return result;
    }

    public void SetEquipped(bool state)
    {
        equipped = state;
    }

    public bool IsPurchased()
    {
        string key = playerPrefabName + "Purchased";
        bool result = IntToBool(PlayerPrefs.GetInt(key));
        return result;
    }

    public void SetPurchased(bool state)
    {
        purchased = state;
    }

    public int BoolToInt(bool value)
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

    public bool IntToBool(int value)
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
