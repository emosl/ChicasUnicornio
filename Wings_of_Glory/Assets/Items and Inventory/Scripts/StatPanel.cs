

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatPanel : MonoBehaviour
{
    [SerializeField] StatsDisplay[] statsDisplays;
    [SerializeField] string[] statNames;

    private Stats[] stats;

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


public void UpdateStatValues()
{
    for (int i = 0; i < stats.Length; i++)
    {
       statsDisplays[i].UpdateStatValue();
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
