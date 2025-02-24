using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{


    public TMP_Text timerText;




    public static UIManager instance; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void UpdateTimer(float time)
    {
        if (timerText != null)
        {
            timerText.text = "TIME: " + time.ToString("F2") + "S";
        }
    }
}
