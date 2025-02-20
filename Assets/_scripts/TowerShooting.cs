using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float firingRate = 1f;

    public Transform target;

    private float fireCountdown = 0.5f;

    public float range = 7f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;


    public bool isFiring = false;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    /// <summary>
    /// updating the enemy target, allowing lock on within a certain range 
    /// </summary>

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }
    private void Update()
    {
        if(target == null)
        { return; }
        if(!isFiring)
        {
          //   StartCoroutine(WaitTime());
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        //TowerShot();


        if (fireCountdown <= 0)
        {
            TowerShot();
            fireCountdown = 1f / firingRate;
        }
        fireCountdown -= Time.deltaTime;

    }

    /// <summary>
    /// Controls instantiation of bullets from the set game object in the scene
    /// </summary>
    private void TowerShot()
    {
        

        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
        //StartCoroutine(WaitTime());

    }
    /// <summary>
    /// waits for time in between bullets 
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitTime()
    {
        isFiring = true;
        
        yield return new WaitForSeconds(firingRate);
        
        isFiring = false;

    
       
        Debug.Log("waiting to shoot bullet");
    }
    /// <summary>
    /// to draw the AOE so that we can visualize it 
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
   
}
