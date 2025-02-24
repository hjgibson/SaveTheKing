using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * [Fain,Jewel]
 * [2/3/2025]
 * [manages scenes]
 */
public class ScreenManager : MonoBehaviour
{
    //Quits game
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    //switches scenes
    public void SwitchScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);

    }
}