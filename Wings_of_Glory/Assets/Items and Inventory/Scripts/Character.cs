
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
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel statsPanel;


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



    private void EquipFromInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Equip((EquippableItem)item);
        }
    }

    private void UnequipFromEquipPanel(Item item)
    {
        if (item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }
    }

    public void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                    item.Unequip(this);
                    statsPanel.UpdateStatValues();
                }
                item.Equip(this);
                statsPanel.UpdateStatValues();
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
        }
    }

    

    
}
