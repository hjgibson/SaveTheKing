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

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
    private float countdown = 2f;

    private int waveNumber = 0;

    public TMP_Text countdownText;

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

        countdownText.text = string.Format("{0:00.00}", countdown);
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
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }




}
