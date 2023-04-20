

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
        // statsDisplays[i].gameObject.SetActive(i < stats.Length);
        // if (statsDisplays[i].NameText != null)
        // {
        //     statsDisplays[i].NameText.text = statNames[i];
        // }
        // statsDisplays[i].Stat = charStats[i];
        statsDisplays[i].gameObject.SetActive(i < stats.Length);
        if (i < stats.Length)
        {
            statsDisplays[i]. Stat = stats[i];
        }
        
    }
}


// public void UpdateStatValues()
// {
//     if (stats == null || statsDisplays == null)
//     {
//         Debug.LogError("Stats or statsDisplays array is not initialized in the StatPanel script.");
//         return;
//     }

//     for (int i = 0; i < stats.Length; i++)
//     {
//         if (statsDisplays[i] == null)
//         {
//             Debug.LogError("statsDisplays element at index " + i + " is null.");
//             continue;
//         }

//         if (statsDisplays[i].ValueText != null)
//         {
//             statsDisplays[i].ValueText.text = statsDisplays[i].Stat.Value.ToString();
//         }
//     }
// }
public void UpdateStatValues()
{
    for (int i = 0; i < stats.Length; i++)
    {
       statsDisplays[i].UpdateStatValue();
    }
}


    // public void UpdateStatNames()
    // {
    //     if (statNames == null || statNames.Length != statsDisplays.Length)
    //     {
    //         Debug.LogError("statNames and statsDisplays arrays are not of equal length");
    //         return;
    //     }

    //     for (int i = 0; i < statNames.Length; i++)
    //     {
    //         if (statsDisplays[i].NameText != null)
    //         {
    //             statsDisplays[i].NameText.text = statNames[i];
    //         }
    //     }
    // }

     public void UpdateStatNames()
    {
        for (int i = 0; i < statNames.Length; i++)
        {
            statsDisplays[i].Name = statNames[i];
        }
    }
}
