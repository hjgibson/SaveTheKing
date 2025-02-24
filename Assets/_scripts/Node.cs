using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Vector3 positionOffset;

    public Color hoverColor;

    private Renderer rend;

    private Color startColor;

    private GameObject towerPrefab;

  //  public int currentTowerCount;

   // public int maxTowers;

   // public GameObject tower2Prefab;


    private void Start()
    {

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        //  currentTowerCount++;
        //  if(currentTowerCount == maxTowers)
        // {
        //    GameObject secondTurret = Instantiate(tower2Prefab, transform.position + positionOffset, transform.rotation);
        //   Destroy(GameObject.FindGameObjectWithTag("Tower1"));
        //   return;
        //  }


        if (towerPrefab != null)
        {
            Debug.Log("Can't Build There!");
            
            return;
        }
       GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        towerPrefab = Instantiate(turretToBuild, transform.position + positionOffset , transform.rotation);

        ///building the turret 
       // Instantiate(gameObject.);
        // Instantiate(tower);
    }
}
