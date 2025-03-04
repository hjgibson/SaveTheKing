using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Points;
    public int startPoints = 0;

    private void Start()
    {
        Points = startPoints;
    }
}
