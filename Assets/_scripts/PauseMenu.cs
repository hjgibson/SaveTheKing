using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;


    public GameObject PauseMenuUI;
    public GameObject PauseButton;


    private void Start()
    {
        PauseMenuUI.SetActive(false);
        PauseButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TogglePause()
    {

        if (GameIsPaused)
        {
            Resume();

        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        Debug.Log("Game Paused");
        PauseMenuUI.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;



    }





}
