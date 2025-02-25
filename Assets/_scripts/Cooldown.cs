using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cooldown : MonoBehaviour 
{

    public float cooldownTime;
    private float _nextSpawnTime;

    public Cooldown(float cooldownTime)
    {
        this.cooldownTime = cooldownTime;
    }
    public bool IsCoolingDown()
    {
        return Time.time < _nextSpawnTime;
    }

    public void StartCooldown()
    {
        Debug.Log("cooling down");
        
        _nextSpawnTime = Time.time + cooldownTime;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(100, 40, 200, 20), "Cooling Down" + cooldownTime);
    }
}
