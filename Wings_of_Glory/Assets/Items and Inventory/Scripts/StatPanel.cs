

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatPanel : MonoBehaviour
{
    [SerializeField] StatsDisplay[] statsDisplays;
    [SerializeField] string[] statNames;

    private Stats[] stats;

    private const int SpeedStatIndex = 2;
    private const int StrengthStatIndex = 0;

    private void OnValidate()
    {
        statsDisplays = GetComponentsInChildren<StatsDisplay>();
        UpdateStatNames();
    }

public void SetStats(params Stats[] charStats)
{
    stats = charStats;
    if (stats.Length > statsDisplays.Length)
    {
        Debug.LogError("Not enough Set Displays");
        return;
    }

    for (int i = 0; i < statsDisplays.Length; i++)
    {
        
        statsDisplays[i].gameObject.SetActive(i < stats.Length);
        if (i < stats.Length)
        {
            statsDisplays[i]. Stat = stats[i];
        }
        
    }
}

private int CalculateSpeedBaseValue(int speed)
{
    int baseValue = 0;
    if (speed == 5)
    {
        baseValue = 0;
    }
    else if (speed == 6)
    {
        baseValue = 1;
    }
    else if (speed == 7)
    {
        baseValue = 2;
    }
    else if (speed == 8)
    {
        baseValue = 3;
    }
    else if (speed == 9)
    {
        baseValue = 4;
    }
    else if (speed == 10)
    {
        baseValue = 5;
    }
    else if (speed == 11)
    {
        baseValue = 6;
    }
    else if (speed == 12)
    {
        baseValue = 7;
    }
    else if (speed == 13)
    {
        baseValue = 8;
    }
    else if (speed == 14)
    {
        baseValue = 9;
    }
    else if (speed == 15)
    {
        baseValue = 10;
    }
    else if (speed < 0)
    {
        baseValue = speed;
    }
    return baseValue;
}

private int CalculateStrengthBaseValue(int strength)
{
    int baseValue = 0;
    if (strength == 8)
    {
        baseValue = 0;
    }
    else if (strength == 9)
    {
        baseValue = 1;
    }
    else if (strength == 10)
    {
        baseValue = 2;
    }
    else if (strength == 11)
    {
        baseValue = 3;
    }
    else if (strength == 12)
    {
        baseValue = 4;
    }
    else if (strength == 13)
    {
        baseValue = 5;
    }
    else if (strength == 14)
    {
        baseValue = 6;
    }
    else if (strength == 15)
    {
        baseValue = 7;
    }
    else if (strength == 16)
    {
        baseValue = 8;
    }
    else if (strength == 17)
    {
        baseValue = 9;
    }
    else if (strength == 18)
    {
        baseValue = 10;
    }
    return baseValue;
}



// public void UpdateStatValues()
// {
//     for (int i = 0; i < stats.Length; i++)
//     {
//        statsDisplays[i].UpdateStatValue();
//     }
// }
  public void UpdateStatValues()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            if (i == SpeedStatIndex)
            {
                // Calculate the base value for Speed and update the display
                int speedBaseValue = CalculateSpeedBaseValue(stats[i].Value);
                statsDisplays[i].UpdateStatValue(speedBaseValue, stats[i].Value);
            }
            else if (i == StrengthStatIndex)
            {
                // Calculate the base value for Strength and update the display
                int strengthBaseValue = CalculateStrengthBaseValue(stats[i].Value);
                statsDisplays[i].UpdateStatValue(strengthBaseValue, stats[i].Value);
            }
            else
            {
                statsDisplays[i].UpdateStatValue();
            }
        }
    }


  

     public void UpdateStatNames()
    {
        for (int i = 0; i < statNames.Length; i++)
        {
            statsDisplays[i].Name = statNames[i];
        }
    }
}
