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
    public batteryplayer batteryplayer;

    public float pickupRange = 1.5f;

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
    public void RemoveItem(Character c){
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
        c.Shield.RemoveAllModifiersFromSource(this);
        c.Speed.RemoveAllModifiersFromSource(this);
    }
    //  public void Equip(Character character)
    // {
    //     character.Strength.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat));
    //     character.Agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat));
    //     character.Shield.AddModifier(new StatModifier(ShieldBonus, StatModType.Flat));
    //     character.Speed.AddModifier(new StatModifier(SpeedBonus, StatModType.Flat));
    // }

    // public void Unequip(Character character)
    // {
    //     character.Strength.RemoveAllModifiersFromSource(this);
    //     character.Agility.RemoveAllModifiersFromSource(this);
    //     character.Shield.RemoveAllModifiersFromSource(this);
    //     character.Speed.RemoveAllModifiersFromSource(this);
    // }


    public void RandomizeBonuses(string itemName)
{
    ItemName = itemName; // Add this line to set the ItemName property
    Debug.Log("RandomizeBonuses called with itemName: " + itemName + ", ItemName set to: " + ItemName);
    switch (itemName)
    {
        case "Bronze":
            StrengthBonus = Random.Range(-2, 2);
            AgilityBonus = Random.Range(-2, 2);
            SpeedBonus = Random.Range(-1, -2);
            ShieldBonus = Random.Range(3, 4);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;

        case "Carrot":
            StrengthBonus = Random.Range(-2,2);
            AgilityBonus = Random.Range(7,8);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-5,-6);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;

        case "Crown":
            StrengthBonus = Random.Range(-5,-6);
            AgilityBonus = Random.Range(-2,2);
            SpeedBonus = Random.Range(7,8);
            ShieldBonus = Random.Range(-2,2);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;

        case "FireShoe":
            StrengthBonus = Random.Range(3,4);
            AgilityBonus = Random.Range(-1,-2);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-2,2);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;

        case "Hat":
            StrengthBonus = Random.Range(-3,-4);
            AgilityBonus = Random.Range(-2,2);
            SpeedBonus = Random.Range(5,6);
            ShieldBonus = Random.Range(-2,2);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;

        case "Headband":
            StrengthBonus = Random.Range(-1,-2);
            AgilityBonus = Random.Range(-2,2);
            SpeedBonus = Random.Range(3,4);
            ShieldBonus = Random.Range(-2,2);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;

        case "Apple":
            StrengthBonus = Random.Range(-2,2);
            AgilityBonus = Random.Range(5,6);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-3,-4);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;

        case "Gold":
            StrengthBonus = Random.Range(-2,2);
            AgilityBonus = Random.Range(-2,2);
            SpeedBonus = Random.Range(-5,-6);
            ShieldBonus = Random.Range(7,8);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;
        
        case "Cake":
            StrengthBonus = Random.Range(-2,2);
            AgilityBonus = Random.Range(3,4);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-1,-2);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;

        case "Silver":
            StrengthBonus = Random.Range(-2,2);
            AgilityBonus = Random.Range(-2,2);
            SpeedBonus = Random.Range(-3,-4);
            ShieldBonus = Random.Range(5,6);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;

        case "RollerShoe":
            StrengthBonus = Random.Range(5,6);
            AgilityBonus = Random.Range(-3,-4);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-2,2);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;

        case "SpikeShoe":
            StrengthBonus = Random.Range(7,8);
            AgilityBonus = Random.Range	(-5,-6);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-2,2);
            batteryplayer.ChangeStrength(StrengthBonus);
            batteryplayer.ChangeAgility(AgilityBonus);
            batteryplayer.ChangeSpeed(SpeedBonus);
            batteryplayer.ChangeShield(ShieldBonus);
            break;


        
    }
}


  


    
}
