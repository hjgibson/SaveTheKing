using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private Cooldown cooldown;

    public Image cooldownImage;

    private void Awake()
    {
        CooldownTime();
    }
    public GameObject standarTurretPrefab;

    private void Start()
    {
            turretToBuild = standarTurretPrefab;
        cooldown = new Cooldown(10); //cooldownImage);
        
    }

    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
       
    return turretToBuild;
     
    }

    public Cooldown GetCooldown() => cooldown;

    public void CooldownTime()
    {
        cooldown = new Cooldown(10);
        if (instance != null)
        {
            Debug.Log("more than one in the scene!");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if(cooldown != null && cooldown.IsCoolingDown())
        {
            cooldown.UpdateCooldownUI();
        }
    }
}
