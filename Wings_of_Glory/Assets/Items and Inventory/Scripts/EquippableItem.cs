using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Head,
    Horseshoe,
    Food,
    Shield,
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int StrengthBonus;
    public int AgilityBonus;
    public int SpeedBonus;
    public int ShieldBonus;
    [Space]
    public int StrengthPercentBonus;
    public int AgilityPercentBonus;
    public int SpeedPercentBonus;
    public int ShieldPercentBonus;
    [Space]
    public EquipmentType EquipmentType;

    
}
