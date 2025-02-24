using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
 * Author: [Fain, Jewel]
 * [Handles wave spawning of enemies]
 */
public class WaveSpawning : MonoBehaviour
{

    public Transform enemy1Prefab; 
    public Transform enemy2Prefab;
    public Transform enemy3Prefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
    private float countdown = 2f;

    private int waveNumber = 0;

    

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        //countdown can't be negative
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

       
    }

    /// <summary>
    /// spawns the enemies in different waves after a period of time
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    /// <summary>
    /// instantiates the enemy prefabs
    /// </summary>
    public void SpawnEnemy()
    {
        Instantiate(enemy1Prefab, spawnPoint.position, spawnPoint.rotation);
    }




}
