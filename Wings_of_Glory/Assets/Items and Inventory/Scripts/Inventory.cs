
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    [SerializeField] Transform itemsParent;
    public ItemSlot[] itemSlots;
    public EquippableItem equippableItem;
    public GameManagerToby gameManagerToby;
     public GameObject fullInventoryPanel;

    public event Action<Item> OnItemRightClickEvent;
    public event Action<Item> OnItemDoubleClickEvent;


    public event Action<Item> OnItemAdded;

    private void Awake()
{
     fullInventoryPanel.SetActive(false);
    for (int i = 0; i < itemSlots.Length; i++)
    {
        itemSlots[i].OnRightClickEvent += HandleRightClick;
        itemSlots[i].OnDoubleClickEvent += HandleDoubleClick;
        itemSlots[i].OnRightClickEvent += OnItemRightClickEvent;
    }
}
    
private void HandleRightClick(Item item)
    {
        
        // Perform any other necessary actions here, like using the item or showing a context menu.
        OnItemRightClickEvent?.Invoke(item);
    }

private void HandleDoubleClick(Item item)
{
    RemoveItem(item);
}





private void OnDestroy()
{
    for (int i = 0; i < itemSlots.Length; i++)
    {
        itemSlots[i].OnRightClickEvent -= HandleRightClick;
    }
}


    private void OnValidate()
    {
        if (itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }

        RefreshUI();
        for (int i = 0; i < itemSlots.Length; i++)
    {
        itemSlots[i].OnDoubleClickEvent += (item) => OnItemDoubleClickEvent?.Invoke(item);
    }
    }

    private void RefreshUI()
{
    int i = 0;
    for (; i < items.Count && i < itemSlots.Length; i++)
    {
        itemSlots[i].Item = items[i];
    }

    for (; i < itemSlots.Length; i++)
    {
        itemSlots[i].Item = null;
    }
}


    // public bool AddItem(Item item)
    // {
    //     Debug.Log("item added");
    //     if (IsFull())
    //     {
    //         return false;
    //     }
    //     //gameManagerToby.GadgetCounter(item.ItemName);
    //     items.Add(item);
    //     OnItemAdded?.Invoke(item);
    //     RefreshUI();
    //     return true;
    // }

    public bool AddItem(Item item)
{
    if (IsFull())
    {
        fullInventoryPanel.SetActive(true);
        Invoke("HideFullInventoryPanel", 2f);
        return false;
    }

    items.Add(item);
    OnItemAdded?.Invoke(item);
    RefreshUI();
    return true;
}

// Add a Coroutine to show the panel and hide it after 2 seconds
private void HideFullInventoryPanel()
{
    fullInventoryPanel.SetActive(false);
}




    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;
    }
}
