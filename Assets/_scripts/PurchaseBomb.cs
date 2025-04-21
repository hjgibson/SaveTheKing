using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PurchaseBomb : MonoBehaviour
{
    public static int bombcount;
    public static int gold;
    public int upgradeCost;
    public int bombCost;
    public static int timer;
   

    public void buybomb()
    {
        if (PlayerStats.gold >= bombCost)
        {
          PlayerStats.gold -= bombCost;
          BombManager.bombcount++;
        }
        else
        {
            Debug.Log("not enough gold");
        }

    }

    public void UpgradeCooldown()
    {
        if (PlayerStats.gold >= upgradeCost)
        {
            PlayerStats.gold -= upgradeCost;
            //BuildManager.timer -= 5;
            Debug.Log("upgraded");
        }
        else
        {
            Debug.Log("not enough gold");
        }

    }
}
