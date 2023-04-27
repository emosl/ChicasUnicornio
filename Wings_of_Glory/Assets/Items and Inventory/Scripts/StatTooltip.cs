using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class StatTooltip : MonoBehaviour
{
   [SerializeField] TMP_Text StatNameText; // Change this to TMP_Text
    [SerializeField] TMP_Text StatModifierLabelText; // Change this to TMP_Text
    [SerializeField] TMP_Text StatModifiersText; // Change this to TMP_Text

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip(Stats stat, string statNames)
    {
        StatNameText.text = GetStatTopText(stat, statNames);

        StatModifiersText.text = GetStatModifierText(stat);
        

        
        
        gameObject.SetActive(true);

    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);

        
    }

    private string GetStatTopText(Stats stat, string statNames)
    {
        sb.Length = 0;
        sb.Append(statNames);
        sb.Append(" ");
        sb.Append(stat.Value);


        if (stat.Value != stat.BaseValue)
        {
            sb.Append(" ( ");
            sb.Append(stat.BaseValue);

            if (stat.Value > stat.BaseValue)
                sb.Append("+");
            
            sb.Append(stat.Value - stat.BaseValue);
            sb.Append(" ( ");
        }
        sb.Append(stat.Value - stat.BaseValue);

        return sb.ToString();


    }

    // private string GetStatModifierText(Stats stat)
    // {
    //     sb.Length = 0;
    //     foreach (StatModifier mod  in stat.StatModifiers)
    //     {
    //         if (sb.Length > 0)
    //             sb.AppendLine();

    //         if (mod.Value > 0)
    //             sb.Append("+");

    //         sb.Append(mod.Value);

    //         EquippableItem item = mod.Source as EquippableItem;

    //         if (item != null)
    //         {
    //             sb.Append(" ");
    //             sb.Append(item.ItemName);
    //         }
    //         else 
    //         {
    //             Debug.LogError("Modifier is not an EquippableItem");
    //         }
            
    //     }
    //     return sb.ToString();


    // }

    private string GetStatModifierText(Stats stat)
{
    sb.Length = 0;
    foreach (StatModifier mod in stat.StatModifiers)
    {
        if (sb.Length > 0)
            sb.AppendLine();

        if (mod.Value > 0)
            sb.Append("+");

        sb.Append(mod.Value);

        EquippableItem item = mod.Source as EquippableItem;

        if (item != null)
        {
            Debug.Log("Item Name: " + item.ItemName); // Debug log to check the item name
            sb.Append(" ");
            sb.Append(item.ItemName);
        }
        else
        {
            Debug.LogError("Modifier is not an EquippableItem");
        }
    }

    string result = sb.ToString();
    Debug.Log("Tooltip Text: " + result); // Debug log to check the final tooltip text
    return result;
}



}
