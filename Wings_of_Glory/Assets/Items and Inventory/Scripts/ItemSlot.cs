
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour , IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler 
{
    [SerializeField] private Item item;
    [SerializeField] private Image itemImage;
    [SerializeField] ItemTooltip tooltip;
    

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

public void OnPointerEnter(PointerEventData eventData)
{
    if (Item is EquippableItem)
    {
        tooltip.ShowTooltip((EquippableItem)Item);

    }
    
}

public void OnPointerExit(PointerEventData eventData)
{
    tooltip.HideTooltip();
}



    protected virtual void OnValidate()
    {
        if (itemImage == null)
        {
            itemImage = GetComponent<Image>();
        }

        if (tooltip == null)
            tooltip = FindObjectOfType<ItemTooltip>();

        UpdateItemImage();
    }



}
