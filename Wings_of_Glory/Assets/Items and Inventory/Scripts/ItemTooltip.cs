using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] TMP_Text ItemNameText; // Change this to TMP_Text
    [SerializeField] TMP_Text ItemSlotText; // Change this to TMP_Text
    [SerializeField] TMP_Text ItemStatsText; // Change this to TMP_Text

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip(EquippableItem item)
    {
        ItemNameText.text = item.ItemName;

        ItemSlotText.text = item.EquipmentType.ToString();

        sb.Length = 0;

        AddStat(item.StrengthBonus, "Strength");
        AddStat(item.AgilityBonus, "Agility");
        AddStat(item.ShieldBonus, "Shield");
        AddStat(item.SpeedBonus, "Speed");

        ItemStatsText.text = sb.ToString();
        
        gameObject.SetActive(true);

    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);

        
    }

    private void AddStat(float value, string statNames)
    {
        if (value != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine();
            if (value > 0)
                sb.Append("+");
            
            sb.Append(value);
            sb.Append(" ");
            sb.Append(statNames);
        }
        
    }
    
    
}
