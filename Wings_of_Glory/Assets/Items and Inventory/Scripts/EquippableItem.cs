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
    public EquipmentType EquipmentType;

    public void Equip(Character c)
    {
        if(StrengthBonus != 0)
        c.Strength.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));

        if(AgilityBonus != 0)
        c.Agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));

        if(ShieldBonus != 0)
        c.Shield.AddModifier(new StatModifier(ShieldBonus, StatModType.Flat, this));

        if(SpeedBonus != 0)
        c.Speed.AddModifier(new StatModifier(SpeedBonus, StatModType.Flat, this));

    }

    public void Unequip(Character c)
    {
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
        c.Shield.RemoveAllModifiersFromSource(this);
        c.Speed.RemoveAllModifiersFromSource(this);

    }

    
}
