using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
   
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI CooldownText;

    private void Update()
    {
        HealthText.text = "HEALTH " + PlayerLives.Health.ToString();
        CooldownText.text = "Tower Cooldown" + GetComponent<BuildManager>().cooldown.ToString();
    }
}
