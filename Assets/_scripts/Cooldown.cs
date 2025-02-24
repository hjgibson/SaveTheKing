using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cooldown
{

    private float cooldownTime;
    private float _nextSpawnTime;

    public Cooldown(float cooldownTime)
    {
        this.cooldownTime = cooldownTime;
    }
    public bool IsCoolingDown()
    {
       Debug.Log(Time.time);
       
       return Time.time < _nextSpawnTime;
    }
    
    public void StartCooldown()
    {
        Debug.Log("cooling down");
       _nextSpawnTime = Time.time + cooldownTime;
    }
   
}
