using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI HealthText;

    private void Update()
    {
        HealthText.text = PlayerLives.Health.ToString() + " HEALTH";
    }
}
