using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int Points;
    public static int gold;
    public TextMeshProUGUI HighscoreText;
    public int startPoints = 0;
    public int startGold = 0;

    private WaveSpawning waveSpawner;

    private void Start()
    {
        Points = startPoints;
        gold = startGold;
    }

    private void Update()
    {
        UpdateHighscoreText();
        CheckHighScore();
    }
    void Highscore()
    {
        PlayerPrefs.SetInt("HighScore", Points);
        PlayerPrefs.GetInt("HighScore");
    }

    void CheckHighScore()
    {
      

        if (waveSpawner == null) return;

        int currentWave = waveSpawner.CurrentWaveNumber;
        int savedWaveHighscore = PlayerPrefs.GetInt("WaveHighScore", 0);

        if ( currentWave > savedWaveHighscore )
        {
            PlayerPrefs.SetInt("WaveHighScore", currentWave);
            UpdateHighscoreText() ;
        }
    }

    void UpdateHighscoreText()
    {
        HighscoreText.text = $"Best Wave: {PlayerPrefs.GetInt("WaveHighScore", 0)}";
    }
}
