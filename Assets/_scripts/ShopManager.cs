using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;

    public static bool GameIsPaused = false;


   // public GameObject PauseMenuUI;
    public GameObject shopButton;


    private void Start()
    {
        shopUI.SetActive(false);
        shopButton.SetActive(true);
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
        shopUI.SetActive(false);
        shopButton.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        Debug.Log("Game Paused");
        shopUI.SetActive(true);
        //shopButton.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;



    }
}
