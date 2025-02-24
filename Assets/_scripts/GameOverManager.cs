using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; 
    private bool isGameOver = false;


    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
       
        if (PlayerLives.Health <= 0 && !isGameOver)
        {
            
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;  
        Time.timeScale = 0f;  
        gameOverPanel.SetActive(true);  
    }

    
    }

