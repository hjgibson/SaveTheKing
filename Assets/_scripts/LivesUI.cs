using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LivesUI : MonoBehaviour
{
    private Cooldown cooldown;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI cooldownText;
    public TextMeshProUGUI ScoreText;

    public void Start()
    {
        cooldown = new Cooldown(10f);
        cooldown.StartCooldown();
        
    }
    private void Update()
    {
        HealthText.text = "HEALTH " + PlayerLives.Health.ToString();

        

        if (cooldown != null )
        {
            cooldownText.text = "Cooldown: " + Mathf.Ceil(cooldown.GetRemainingCooldownTime()).ToString() + "s"; // Show remaining time
        }
        else
        {
            Debug.Log("not working");
        }

        ScoreText.text = "Score " + PlayerStats.Points.ToString();
     
    }

    public void RestartCooldown()
    {
        cooldown.StartCooldown();
    }
}
