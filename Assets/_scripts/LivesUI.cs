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
    private Image cooldownUI;
    public void Start()
    {
        cooldown = new Cooldown(10f, cooldownUI);
        cooldown.StartCooldown();
        
    }
    private void Update()
    {
        HealthText.text = "HEALTH " + PlayerLives.Health.ToString();

        //float remainingTime = cooldown.GetRemainingCooldownTime();

        if (cooldown != null )
        {
            cooldownText.text = "Cooldown: " + Mathf.Ceil(cooldown.GetRemainingCooldownTime()).ToString() + "s"; // Show remaining time
        }
        else
        {
            Debug.Log("not working");
        }
        //cooldownTimerText.text = "Cooldown: " + Mathf.Ceil(remainingTime).ToString() + "s";
       

        // CooldownText.text = "Tower Cooldown" + GetComponent<BuildManager>().cooldown.ToString();
    }

    public void RestartCooldown()
    {
        cooldown.StartCooldown();
    }
}
