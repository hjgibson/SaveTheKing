using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject winPanel;
    private bool isGameOver = false;


    private void Start()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver)
            return;


        if (PlayerLives.Health <= 0 && !isGameOver)
        {
            
            GameOver();
        }
    }

    public void WinLevel()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        winPanel.SetActive(true);

    }

    void GameOver()
    {
        isGameOver = true;  
        Time.timeScale = 0f;  
        gameOverPanel.SetActive(true);  
    }

    
    }

