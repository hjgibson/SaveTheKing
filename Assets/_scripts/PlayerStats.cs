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

    private void Start()
    {
        Points = startPoints;
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
        if(Points > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Points);
            UpdateHighscoreText();
        }
    }

    void UpdateHighscoreText()
    {
        HighscoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
