using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;

    public event Action<Item> OnItemRightClickEvent;


    private void Awake()
{
    for (int i = 0; i < equipmentSlots.Length; i++)
    {
        equipmentSlots[i].OnRightClickEvent += HandleRightClick;
        equipmentSlots[i].OnRightClickEvent += OnItemRightClickEvent;
    }
}

public List<EquippableItem> EquippedItems
{
    get
    {
        List<EquippableItem> equippedItems = new List<EquippableItem>();
        foreach (EquipmentSlot slot in equipmentSlots)
        {
            if (slot.Item != null)
            {
                Debug.Log("Equpped item" + slot.Item.name);
                equippedItems.Add((EquippableItem)slot.Item);
            }
        }
        return equippedItems;
    }
}


private void HandleRightClick(Item item)
    {
        Debug.Log("Right-clicked item: " + item.name);
        // Perform any other necessary actions here, like using the item or showing a context menu.
        OnItemRightClickEvent?.Invoke(item);
    }




private void OnDestroy()
{
    for (int i = 0; i < equipmentSlots.Length; i++)
    {
        equipmentSlots[i].OnRightClickEvent -= HandleRightClick;
    }
}

    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }

    public int GetNumberOfOccupiedSlots()
{
    int occupiedSlots = 0;

    for (int i = 0; i < equipmentSlots.Length; i++)
    {
        if (equipmentSlots[i].Item != null)
        {
            occupiedSlots++;
        }
    }

    return occupiedSlots;
}

}
