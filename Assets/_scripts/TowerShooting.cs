using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float firingRate = 1f;

    public bool isFiring = false;
    private void Update()
    {
        if(!isFiring)
        {
            StartCoroutine(WaitTime());
        }
        //TowerShot();
    }

    /// <summary>
    /// Controls instantiation of bullets from the set game object in the scene
    /// </summary>
    private void TowerShot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        //StartCoroutine(WaitTime());

    }

    IEnumerator WaitTime()
    {
        isFiring = true;
        
        yield return new WaitForSeconds(firingRate);
        
        isFiring = false;

        TowerShot();
       
        Debug.Log("waiting to shoot bullet");
    }
}
