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
        playerPrefabLocation = "Prefabs/" + playerPrefabName;
    }
    
    public string GetPrefabLocation()
    {
        return playerPrefabLocation;
    }

    public bool IsEquipped()
    {
        return equipped;
    }

    public void SetEquipped(bool state)
    {
        equipped = state;
    }

    public bool IsPurchased()
    {
        return purchased;
    }

    public void SetPurchased(bool state)
    {
        purchased = state;
    }
}
