using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cooldown 
{

    public float cooldownTime;
    public float _nextSpawnTime;


    //private Image cooldownUI;
    public Cooldown(float cooldownTime)// Image cooldownUI)
    {
        this.cooldownTime = cooldownTime;
     //   this.cooldownUI = cooldownUI;
        _nextSpawnTime = 0;
      //  if(cooldownUI != null)
       // {
        //    cooldownUI.fillAmount = 0f;
       // }

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

    public void UpdateCooldownUI()
    {
       // if (cooldownUI != null)
       // {
       //     float elapsedTime = Mathf.Clamp01(1 - (GetRemainingCooldownTime() / cooldownTime));
       //     cooldownUI.fillAmount = elapsedTime;
      //  }
    }
}
