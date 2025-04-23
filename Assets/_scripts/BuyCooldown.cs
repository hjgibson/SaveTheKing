using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCooldown : MonoBehaviour
{
    public static int upgradeCost;
    public int timer;

    public void Start()
    {
        timer = 10;
        upgradeCost = 25;
    }
   
    public void UpgradeCooldown()
    {
        if (PlayerStats.gold >= upgradeCost)
        {
            PlayerStats.gold -= upgradeCost;
            timer--;
            upgradeCost += 25;
            //upgraded = true;
        }
        else
        {
            Debug.Log("not enough gold");
        }

    }
}
