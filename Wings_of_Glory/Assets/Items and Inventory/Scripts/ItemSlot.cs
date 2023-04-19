
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private Item item;
    [SerializeField] private Image itemImage;
    

    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            UpdateItemImage();
        }
    }

    public event Action<Item> OnRightClickEvent;

    private void UpdateItemImage()
    {
        
        if (itemImage == null)
        {
            return;
        }

        if (item == null)
        {
            itemImage.enabled = false;
        }
        else
        {
            itemImage.sprite = item.Icon;
            itemImage.enabled = true;
        }
    }

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     if (eventData != null && Input.GetMouseButtonDown(1))
    //     {
    //         if (Item != null && OnRightClickEvent != null)
    //         {
    //             OnRightClickEvent(Item);
    //         }

    //     }
    // }

public void OnPointerClick(PointerEventData eventData)
{


    if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
    {
   

        if (Item != null && OnRightClickEvent != null)
        {
           
            OnRightClickEvent(Item);
        }
    }
}



    protected virtual void OnValidate()
    {
        if (itemImage == null)
        {
            itemImage = GetComponent<Image>();
        }

        UpdateItemImage();
    }
}
