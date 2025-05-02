using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public TextMeshProUGUI HighscoreText;

    private void Start()
    {
        UpdateHighscoreText();
    }

    // Call this when a wave finishes to update high score
    public void TryUpdateHighScore(int currentWave)
    {
        int savedWaveHighScore = PlayerPrefs.GetInt("WaveHighScore", 0);

        if (currentWave > savedWaveHighScore)
        {
            PlayerPrefs.SetInt("WaveHighScore", currentWave);
            UpdateHighscoreText();
        }
    }

    public void UpdateHighscoreText()
    {
        int savedWaveHighScore = PlayerPrefs.GetInt("WaveHighScore", 0);
        HighscoreText.text = $"Best Wave: {savedWaveHighScore}";
    }
}


