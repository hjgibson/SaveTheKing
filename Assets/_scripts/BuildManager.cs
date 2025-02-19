using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if( instance != null)
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
}
