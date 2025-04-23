using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public GameObject bomb;
    public static int bombcount = 0;
    private Camera cam;
    private bool holdingdown;

    private void Start()
    {
        cam = Camera.main;
    }

    public void Update()
    {
        holdingdown = !Input.GetMouseButtonUp(0);
        if (bombcount > 0)
        {

            Debug.Log(bombcount.ToString());
            SpawnAtMousePos();

        }
        else
        {
            Debug.Log("no bombs");
        }
    }
    private void SpawnAtMousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holdingdown = true;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Path"))
            {
               
                Instantiate(bomb, hit.point, Quaternion.identity);
                bombcount--;
            }
            
        }
    }
}
