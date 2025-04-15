using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PurchaseBomb : MonoBehaviour
{
    public static int bombcount;
    public static int gold;
    public int bombCost;
   

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
}
