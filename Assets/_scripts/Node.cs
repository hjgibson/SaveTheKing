using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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


    private Cooldown cooldown = null;

    private bool firstClick = false;

    private Vector3 selectedPosition;

    //  public int currentTowerCount;

    // public int maxTowers;

    // public GameObject tower2Prefab;


    private void Start()
    {
        cooldown = BuildManager.instance.GetCooldown();
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

       if (cooldown.IsCoolingDown()) return;

        if (towerPrefab != null)
        {
            Debug.Log("Can't Build There!");

            return;
        }
        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        Debug.Log("Is this the place you want to build?");
        //towerPrefab = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
     
        
        // Check if it's the first click
        if (!firstClick)
        {
            // First click: Select the position for tower placement
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                selectedPosition = hit.point; 
                firstClick = true;             
                Debug.Log("Position selected! Click again to confirm placement.");
            }
        }
        else
        {
            // Second click: Place the tower at the selected position
            if(towerPrefab == null)
            {
                towerPrefab = Instantiate(turretToBuild, selectedPosition + positionOffset, transform.rotation);
                cooldown.StartCooldown(); 

                Debug.Log("CoolDown started! wait a few seconds");

                firstClick = false; 
                Debug.Log("Tower placed at " + selectedPosition);
            }
         
        }
        //GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        // towerPrefab = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

        
        









        ///building the turret 
        // Instantiate(gameObject.);
        // Instantiate(tower);
    }

}
