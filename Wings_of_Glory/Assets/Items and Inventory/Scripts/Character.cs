
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Character : MonoBehaviour
// {
//     public Stats Strength;
//     public Stats Agility;
//     public Stats Shield;
//     public Stats Speed;

//     public Inventory inventory;
//     [SerializeField] EquipmentPanel equipmentPanel;
//     [SerializeField] StatPanel statsPanel;
//     [SerializeField] private Toby toby;


// private void Awake()
// {
//     if (statsPanel == null || inventory == null || equipmentPanel == null)
//     {
//         Debug.LogError("One or more serialized fields are not assigned in the Character script.");
//         return;
//     }

//     statsPanel.SetStats(Strength, Agility, Speed, Shield);
//     statsPanel.UpdateStatValues();
//     inventory.OnItemRightClickEvent += EquipFromInventory;
//     equipmentPanel.OnItemRightClickEvent += UnequipFromEquipPanel;
// }



//     private void EquipFromInventory(Item item)
//     {
//         if (item is EquippableItem)
//         {
//             Equip((EquippableItem)item);
//         }
//     }

//     private void UnequipFromEquipPanel(Item item)
//     {
//         if (item is EquippableItem)
//         {
//             Unequip((EquippableItem)item);
//         }
//     }


// private bool bonusApplied_Speed = false;
// private bool bonusApplied_Strength = false;

// private void Equip(EquippableItem item)
// {
//     if (inventory.RemoveItem(item))
//     {
//         EquippableItem previousItem;
//         if (equipmentPanel.AddItem(item, out previousItem))
//         {
//             if (previousItem != null)
//             {
//                 inventory.AddItem(previousItem);
//                 item.Unequip(this);
//                 statsPanel.UpdateStatValues();
//             }

//             // Apply strength bonus if the item has a positive strength value and the bonus has not been applied yet
//             if (!bonusApplied_Strength && item.StrengthBonus > 0)
//             {
//                 Strength.BaseValue += 8;
//                 bonusApplied_Strength = true;
//             }
            
//             // Apply speed bonus if the item has a positive speed value and the bonus has not been applied yet
//             if (!bonusApplied_Speed && item.SpeedBonus > 0)
//             {
//                 Speed.BaseValue += 5;
//                 bonusApplied_Speed = true;
//             }

//             item.Equip(this);
//             statsPanel.UpdateStatValues();
//             toby.UpdateStats(Strength.Value, Shield.Value, Agility.Value, Speed.Value); // Call UpdateStats method in Toby
//         }
//         else
//         {
//             inventory.AddItem(item);
//         }
//     }
// }



// public void Unequip(EquippableItem item)
// {
//     if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
//     {
//         item.Unequip(this);
//         statsPanel.UpdateStatValues();
//         inventory.AddItem(item);
//         toby.UpdateStats(Strength.Value, Shield.Value, Agility.Value, Speed.Value); // Call UpdateStats method in Toby
//     }
// }

    

    
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Stats Strength;
    public Stats Agility;
    public Stats Shield;
    public Stats Speed;

    public Inventory inventory;
    // [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel statsPanel;
    [SerializeField] private Toby toby;
    [SerializeField] private batteryplayer batteryPlayer;
    public EquipmentPanel equipmentPanel;
    public GameManagerToby gameManagerToby;


    private void Awake()
    {
        if (statsPanel == null || inventory == null || equipmentPanel == null)
        {
            Debug.LogError("One or more serialized fields are not assigned in the Character script.");
            return;
        }

        statsPanel.SetStats(Strength, Agility, Speed, Shield);
        statsPanel.UpdateStatValues();
        inventory.OnItemRightClickEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickEvent += UnequipFromEquipPanel;
    }

    public EquipmentPanel GetEquipmentPanel()
{
    return equipmentPanel;
}


    private void EquipFromInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Equip((EquippableItem)item);
        }
    }

    public void UnequipFromEquipPanel(Item item)
    {
        if (item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }
    }
    private bool bonusApplied_Speed = false;
    private bool bonusApplied_Strength = false;


    private void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    statsPanel.UpdateStatValues();
                }
                if (!bonusApplied_Strength && item.StrengthBonus > 0)
                {
                    Strength.BaseValue += 8;
                    bonusApplied_Strength = true;
                }
                
                // Apply speed bonus if the item has a positive speed value and the bonus has not been applied yet
                if (!bonusApplied_Speed && item.SpeedBonus > 0)
                {
                    Speed.BaseValue += 5;
                    bonusApplied_Speed = true;
                }

                item.Equip(this);
                statsPanel.UpdateStatValues();
                toby.UpdateStats(Strength.Value, Shield.Value, Agility.Value, Speed.Value); // Call UpdateStats method in Toby

                batteryPlayer.ChangeAgility(Agility.Value);
                batteryPlayer.ChangeShield(Shield.Value);
                batteryPlayer.ChangeSpeed(Speed.Value);
                batteryPlayer.ChangeStrength(Strength.Value);
               
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
                if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            statsPanel.UpdateStatValues();
            inventory.AddItem(item);
            toby.UpdateStats(Strength.Value, Shield.Value, Agility.Value, Speed.Value); // Call UpdateStats method in Toby

            batteryPlayer.ChangeAgility(Agility.Value);
            batteryPlayer.ChangeShield(Shield.Value);
            batteryPlayer.ChangeSpeed(Speed.Value);
            batteryPlayer.ChangeStrength(Strength.Value);
           
        }
    }
}


