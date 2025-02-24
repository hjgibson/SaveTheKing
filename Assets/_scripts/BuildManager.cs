using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private Cooldown cooldown;



    private void Awake()
    {
        cooldown = new Cooldown(3);
        if ( instance != null)
        {
            Debug.Log("more than one in the scene!");
            return;
        }
        instance = this; 
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
    

}
