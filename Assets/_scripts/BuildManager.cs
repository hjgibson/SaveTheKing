using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private Cooldown cooldown;



    private void Awake()
    {
        CooldownTime();
    }
    public GameObject standarTurretPrefab;

    private void Start()
    {
            turretToBuild = standarTurretPrefab;
        
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
    

}
