using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cooldown 
{

    public float cooldownTime;
    public float _nextSpawnTime;

    public Cooldown(float cooldownTime)
    {
        this.cooldownTime = cooldownTime;
        _nextSpawnTime = 0;
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
    public float GetRemainingCooldownTime()
    {
        return Mathf.Max(0f, _nextSpawnTime - Time.time); // Return the remaining time, or 0 if the cooldown is done
    }


}
