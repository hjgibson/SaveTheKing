using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public static int Health;
    public int startHealth = 100;

    private void Start()
    {
        Health = startHealth;
    }
}
