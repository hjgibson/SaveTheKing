using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private static Cooldown cooldown;
    public static int gold;
    public static int upgradeCost;
    public Image cooldownImage;
    
    public int timer;
    public TextMeshProUGUI UpgradesCost;

    //public bool upgraded;

    private void Awake()
    {
        //upgraded = false;
        CooldownTime();
    }
    public GameObject standarTurretPrefab;

    private void Start()
    {
        timer = 10;
        upgradeCost = 100;
        //upgraded = false;
        turretToBuild = standarTurretPrefab;
        
        //cooldown = new Cooldown(10); //cooldownImage);
        
    }

    private void Update()
    {
        CooldownTime();
        if (timer > 5)
        {
            UpgradesCost.text = "" + upgradeCost.ToString();
        }
        else
        {
            UpgradesCost.text = "MAX";
        }
        
    }
    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
       
    return turretToBuild;
     
    }

    public Cooldown GetCooldown() => cooldown;

    public void CooldownTime()
    {
        cooldown = new Cooldown(timer);
        if (instance != null)
        {
            Debug.Log("more than one in the scene!");
            return;
        }
        instance = this;
        /*if (upgraded == true)
        {
            cooldown = new Cooldown(timer = 5);
            Debug.Log("upgraded");
            if (instance != null)
            {
                Debug.Log("more than one in the scene!");
                return;
            }
            //instance = this;
        } 
        else
        {
            cooldown = new Cooldown(timer);
            if (instance != null)
            {
                Debug.Log("more than one in the scene!");
                return;
            }
            //instance = this;
        }
        instance = this;
        */


    }

    public void UpgradeCooldown()
    {
        if (timer > 5)
        {
            if (PlayerStats.gold >= upgradeCost)
            {
                PlayerStats.gold -= upgradeCost;
                timer--;
                upgradeCost += 100;
               
                //upgraded = true;
            }
            else
            {
                Debug.Log("not enough gold");
            }
        }
        else
        {
           
        }
      

    }
    /* public void UpgradeCooldown()
     {
         if (PlayerStats.gold >= upgradeCost)
         {
             PlayerStats.gold -= upgradeCost;
             timer = 5;
             //upgraded = true;
         }
         else
         {
             Debug.Log("not enough gold");
         }

     }

     */
    // private void Update()
    //{
    //  if(cooldown != null && cooldown.IsCoolingDown())
    //  {
    //      cooldown.UpdateCooldownUI();
    //  }
    // }

}
