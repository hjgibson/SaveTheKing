using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class gridGenerator : MonoBehaviour
{
    public GameObject nodePrefab;

    public GameObject roadPrefab;

    public int gridSizeX = 10;

    public int gridSizeZ = 15;

    public float spacing = 1f;

    public float roadSpacing = 1f;


    public Vector3 pointA = new Vector3(0,0,0);
    public Vector3 pointB = new Vector3(15, 0, 26);

    public Quaternion rotation = Quaternion.Euler(0f,90f,0f);
    public Quaternion firstRotation = Quaternion.Euler(0f, 0f, 0f);


    private bool initialRotate = true ;
    private void Start()
    {
        GenerateGrid();
        GenerateRoad(pointA, pointB);
    }
    /// <summary>
    /// generates the nodes in a 10 by 15 grid
    /// </summary>
    private void GenerateGrid()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                Vector3 position = new Vector3(x * spacing,0, z * spacing);
                Instantiate(nodePrefab, position, Quaternion.identity);
            }
        }
    }


    private void GenerateRoad(Vector3 start, Vector3 end)
    {
        Vector3 dir = (end-start).normalized;
        float distance = Vector3.Distance(start,end);

        

        for(float t = 0; t <= distance; t += roadSpacing)
        {
            Vector3 roadPosition = start + dir * t;
            roadPosition.y = 1;


            roadPosition.x = Mathf.Round(roadPosition.x / roadSpacing) * roadSpacing;
            roadPosition.z = Mathf.Round(roadPosition.z / roadSpacing) * roadSpacing;
            //  roadPosition.x += Random.Range(-0.2f, 0.2f);
            //roadPosition.z = +Random.Range(-0.2f, 0.2f);

            if (initialRotate == true)
            {
                Instantiate(roadPrefab, roadPosition, firstRotation);
                //firstRotation = rotation;
                initialRotate = false;
            }

            else
            {
                Instantiate(roadPrefab, roadPosition, rotation);
                rotation = Quaternion.Euler(0f, Random.Range(0, 4) * 90f, 0f); 
               // rotation = firstRotation;
                
            }
                
            }
     
           
            
        
    }
}
