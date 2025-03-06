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

    private float Timer = 0;



    void Update()
    {
        Timer += Time.deltaTime;

        if (UIManager.instance != null)
        {
            UIManager.instance.UpdateTimer(Timer);
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        //countdown can't be negative
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

       
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Freezes the game
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
        int randomEnemy = Random.Range(0, 3); // Generates a random number between 0 and 2

        Transform enemyToSpawn;

        switch (randomEnemy)
        {
            case 0:
                enemyToSpawn = enemy1Prefab;
                break;
            case 1:
                enemyToSpawn = enemy2Prefab;
                break;
            case 2:
                enemyToSpawn = enemy3Prefab;
                break;
            default:
                enemyToSpawn = enemy1Prefab; 
                break;
        }

        Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
    



}
