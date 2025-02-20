using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    //public Transform enemyPrefab;
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveNumber = 0;
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {

        Wave wave = waves[waveNumber];

        Debug.Log("Wave Incoming");
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemiesBlue(wave.blueEnemy);
            SpawnEnemiesYellow(wave.yellowEnemy);
            SpawnEnemiesRed(wave.redEnemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waveNumber++;

        //when player reaches end of level activate scene switch to next level
        if (waveNumber == waves.Length)
        {
            Debug.Log("Level Complete");
            this.enabled = false;
        }
    }
    void SpawnEnemiesBlue (GameObject blueEnemy)
    {
        Instantiate(blueEnemy, spawnPoint.position, spawnPoint.rotation);
       

        EnemiesAlive++;
    }
    void SpawnEnemiesYellow (GameObject yellowEnemy)
    {
        
        Instantiate(yellowEnemy, spawnPoint.position, spawnPoint.rotation);
        

        EnemiesAlive++;
    }
    void SpawnEnemiesRed (GameObject redEnemy)
    {
        Instantiate(redEnemy, spawnPoint.position, spawnPoint.rotation);

        EnemiesAlive++;
    }
}
