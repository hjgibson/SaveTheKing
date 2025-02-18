using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private Renderer rend;

    private Color startColor;

    public GameObject towerPrefab;

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
        if (towerPrefab != null)
        {
            Debug.Log("Can't Build There!");
            Instantiate(towerPrefab, Input.mousePosition, Quaternion.identity );
            return;
        }

        ///building the turret 
       // Instantiate(gameObject.)
     //  Instantiate(tower);
    }
}
