// This script is used to state the type of equipment that the character can use and to generate the random items that will be used in the game, as well as to add the bonus to the character's stats.
// Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
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

            break;

        case "Carrot":
            StrengthBonus = Random.Range(-2,2);
            AgilityBonus = Random.Range(7,8);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-5,-6);
  
            break;

        case "Crown":
            StrengthBonus = Random.Range(-5,-6);
            AgilityBonus = Random.Range(-2,2);
            SpeedBonus = Random.Range(7,8);
            ShieldBonus = Random.Range(-2,2);

            break;

        case "FireShoe":
            StrengthBonus = Random.Range(3,4);
            AgilityBonus = Random.Range(-1,-2);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-2,2);

            break;

        case "Hat":
            StrengthBonus = Random.Range(-3,-4);
            AgilityBonus = Random.Range(-2,2);
            SpeedBonus = Random.Range(5,6);
            ShieldBonus = Random.Range(-2,2);

            break;

        case "Headband":
            StrengthBonus = Random.Range(-1,-2);
            AgilityBonus = Random.Range(-2,2);
            SpeedBonus = Random.Range(3,4);
            ShieldBonus = Random.Range(-2,2);
  
            break;

        case "Apple":
            StrengthBonus = Random.Range(-2,2);
            AgilityBonus = Random.Range(5,6);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-3,-4);

            break;

        case "Gold":
            StrengthBonus = Random.Range(-2,2);
            AgilityBonus = Random.Range(-2,2);
            SpeedBonus = Random.Range(-5,-6);
            ShieldBonus = Random.Range(7,8);

            break;
        
        case "Cake":
            StrengthBonus = Random.Range(-2,2);
            AgilityBonus = Random.Range(3,4);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-1,-2);

            break;

        case "Silver":
            StrengthBonus = Random.Range(-2,2);
            AgilityBonus = Random.Range(-2,2);
            SpeedBonus = Random.Range(-3,-4);
            ShieldBonus = Random.Range(5,6);

            break;

        case "RollerShoe":
            StrengthBonus = Random.Range(5,6);
            AgilityBonus = Random.Range(-3,-4);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-2,2);

            break;

        case "SpikeShoe":
            StrengthBonus = Random.Range(7,8);
            AgilityBonus = Random.Range	(-5,-6);
            SpeedBonus = Random.Range(-2,2);
            ShieldBonus = Random.Range(-2,2);

            break;


        
    }
}


  


    
}
