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
    
    public string getPrefabLocation()
    {
        return playerPrefabLocation;
    }

    public bool isEquipped()
    {
        return equipped;
    }

    public void setEquipped(bool state)
    {
        equipped = state;
    }

    public bool isPurchased()
    {
        return purchased;
    }

    public void setPurchased(bool state)
    {
        purchased = state;
    }
}
