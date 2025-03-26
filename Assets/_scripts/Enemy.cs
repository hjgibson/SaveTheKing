using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int enemyDamage;
    public float startHealth = 100;
    private float health;
    public int Points = 0;
    private Transform path;
    private int wavepointIndex = 0;
    
    private Transform enemyTransform;
    public int pointamount;

    public Image healthBar;

    void Start ()
    {
        path = Waypoints.waypoint[0];
        enemyTransform = transform;
        health = startHealth;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {

        WaveSpawning.EnemiesAlive--;

        //WaveSpawner.EnemiesAlive--;

        PlayerStats.Points += pointamount;
        WaveSpawning.EnemiesAlive--;
        if (WaveSpawning.EnemiesAlive < 0)
        {
            WaveSpawning.EnemiesAlive = 0;
        }
        Destroy(gameObject);
    }
    void Update ()
    {
        Vector3 dir = path.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, path.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        LookAtWaypoint();
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoint.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        path = Waypoints.waypoint[wavepointIndex];
    }

    void LookAtWaypoint()
    {
        Vector3 directionToWaypoint = path.position - enemyTransform.position;

        Quaternion targetRotation = Quaternion.LookRotation(directionToWaypoint);

        enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    void EndPath ()
    {
        PlayerLives.Health -= enemyDamage;


        WaveSpawning.EnemiesAlive--;

        //WaveSpawner.EnemiesAlive--;
        WaveSpawning.EnemiesAlive--;
        if (WaveSpawning.EnemiesAlive < 0)
        {
            WaveSpawning.EnemiesAlive = 0;
        }

        Destroy(gameObject);
     
    }

   
}
