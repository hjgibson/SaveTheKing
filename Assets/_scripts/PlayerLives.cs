using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public static int Lives;
    public int startLives = 20;

    private void Start()
    {
        Lives = startLives;
    }
}
