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
    public static int EnemiesAlive = 0;

    private GameOverManager gameManager;

    public Wave[] waves;


    /*
    public Transform enemy1Prefab;
    public Transform enemy2Prefab;
    public Transform enemy3Prefab;
    */
    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
    private float countdown = 2f;

    private int waveNumber = 0;

    private float Timer = 0;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameOverManager>();
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (UIManager.instance != null)
        {
            UIManager.instance.UpdateTimer(Timer);
        }

        Debug.Log($"WaveNumber: {waveNumber}, EnemiesAlive: {EnemiesAlive}");

        if (EnemiesAlive > 0)
        {
            return;
        }
        if (waveNumber == waves.Length && EnemiesAlive == 0)
        {
            Debug.Log("level won");
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
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
        Wave currentWave = waves[waveNumber]; // Get the current wave

        for (int i = 0; i < currentWave.count; i++)
        {
            SpawnEnemy(currentWave); // Pass the current wave to SpawnEnemy
            yield return new WaitForSeconds(1f / currentWave.rate);
        }

        waveNumber++;


     
    }
    /// <summary>
    /// instantiates the enemy prefabs
    /// </summary>
    public void SpawnEnemy(Wave currentWave)
    {
        int randomEnemy = Random.Range(0, currentWave.enemyTypes.Length); // Randomly select from the current wave's enemy types
        Transform enemyToSpawn = null;
        switch (randomEnemy)
        {
            case 0:
                enemyToSpawn = currentWave.enemyTypes[0];
                break;
            case 1:
                if (currentWave.enemyTypes.Length > 1)
                    enemyToSpawn = currentWave.enemyTypes[1];
                break;
            case 2:
                if (currentWave.enemyTypes.Length > 2)
                    enemyToSpawn = currentWave.enemyTypes[2];
                break;
            default:
                enemyToSpawn = currentWave.enemyTypes[0];
                break;
        }

        Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
        Debug.Log("Enemy spawned. EnemiesAlive: " + WaveSpawning.EnemiesAlive);


    }




}
