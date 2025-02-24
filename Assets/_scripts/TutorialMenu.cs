using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{

    public GameObject TutorialMenuUI;
    public GameObject XButton;


    void Start()
    {
       
        TutorialMenuUI.SetActive(true);

      
        Time.timeScale = 0f;

        
    }

  
    public void CloseTutorial()
    {

        TutorialMenuUI.SetActive(false);

        Time.timeScale = 1f;
    }






}
