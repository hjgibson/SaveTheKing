using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    public GameObject tutorialPopup;

    private bool isOpen = false;

    void Start()
    {
        // Ensure popup is hidden and time is running at game start
        if (tutorialPopup.activeSelf)
        {
            tutorialPopup.SetActive(false);
        }
        
    }

    public void TogglePopup()
    {
        isOpen = !isOpen;
        tutorialPopup.SetActive(isOpen);

        // Pause or resume time
       // Time.timeScale = isOpen ? 0f : 1f;
    }
}

