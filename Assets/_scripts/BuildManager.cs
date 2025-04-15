using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private static Cooldown cooldown;
    public static int gold;
    public int upgradeCost;
    public Image cooldownImage;

    public bool upgraded;

    private void Awake()
    {
        upgraded = false;
        CooldownTime();
    }
    public GameObject standarTurretPrefab;

    private void Start()
    {
            turretToBuild = standarTurretPrefab;
        
        //cooldown = new Cooldown(10); //cooldownImage);
        
    }

    private void Update()
    {
        CooldownTime();
    }
    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
       
    return turretToBuild;
     
    }

    public Cooldown GetCooldown() => cooldown;

    public void CooldownTime()
    {
        if (upgraded = true)
        {
            cooldown = new Cooldown(5);
            if (instance != null)
            {
                Debug.Log("more than one in the scene!");
                return;
            }
            instance = this;
        }
        else
        {
            cooldown = new Cooldown(10);
            if (instance != null)
            {
                Debug.Log("more than one in the scene!");
                return;
            }
            instance = this;
        }
        instance = this;


    }
    public void UpgradeCooldown()
    {
        if (PlayerStats.gold >= upgradeCost)
        {
            PlayerStats.gold -= upgradeCost;
            upgraded = true;
        }
        else
        {
            Debug.Log("not enough gold");
        }

    }


    // private void Update()
    //{
    //  if(cooldown != null && cooldown.IsCoolingDown())
    //  {
    //      cooldown.UpdateCooldownUI();
    //  }
    // }
}
