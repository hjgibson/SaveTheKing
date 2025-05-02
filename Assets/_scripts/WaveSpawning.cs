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

    private bool isWaveComplete = false;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
  

    private int waveNumber = 0;

    private float enemyCheckDelay = 2f;
    private float lastEnemyCheckTime = 0f;

    public int CurrentWaveNumber => waveNumber;

    public GameObject buildPhasePanel;
    public TMP_Text waveText;

    private float Timer = 0;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameOverManager>();
    }

    void FixedUpdate()
    {
        Timer += Time.deltaTime;

        if (UIManager.instance != null)
        {
            UIManager.instance.UpdateTimer(Timer);
        }

        Debug.Log($"WaveNumber: {waveNumber}, EnemiesAlive: {EnemiesAlive}");

        // If enemies are still alive, don't enter build phase
        if (EnemiesAlive > 0)
        {
            isWaveComplete = false; // Reset wave completion status
            return; // Exit if there are still enemies
        }

        // Check if the wave is complete (all enemies dead)
        if (!isWaveComplete && Time.time - lastEnemyCheckTime > enemyCheckDelay && EnemiesAlive == 0)
        {
            isWaveComplete = true; // Mark wave as complete
            Debug.Log("Wave Complete. Show build phase UI.");
            ShowBuildPhaseUI(); // Show build phase UI
        }

        // If the wave count is complete, handle victory
        if (waveNumber == waves.Length)
        {
            Debug.Log("Level Won");
            gameManager.WinLevel();
            this.enabled = false;
            return;
        }
  

    }


    void ShowBuildPhaseUI()
    {
        buildPhasePanel.SetActive(true); // Show the build phase panel
        waveText.text = "Wave: " + (waveNumber + 1);
        Time.timeScale = 0f; // can change to 1 to allow merge to work during build pahse, but it can work endlessly
        
    }

    public void StartNextWave()
    {
        if (EnemiesAlive == 0) // Only start the wave if no enemies remain
        {
            buildPhasePanel.SetActive(false);
            Time.timeScale = 1f;
            StartCoroutine(SpawnWave());
        }
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

        HighscoreManager highScoreManager = FindObjectOfType<HighscoreManager>();
        if (highScoreManager != null)
        {
            highScoreManager.TryUpdateHighScore(waveNumber);
        }

        isWaveComplete = false; // Reset wave complete status when the next wave starts

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
