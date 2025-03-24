using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;

    public void ToggleShop()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }
}
