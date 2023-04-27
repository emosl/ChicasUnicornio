
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour , IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler 
{
    public  Item item;
    public Image itemImage;
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
public event Action<Item> OnDoubleClickEvent;

public void OnDoubleClick()
{
     
    if (Item != null)
    {
        OnDoubleClickEvent?.Invoke(Item);
    }
}

private float lastClickTime;
private const float doubleClickTime = 0.2f;

    public void OnPointerClick(PointerEventData eventData)
    {


        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
    

            if (Item != null && OnRightClickEvent != null)
            {
            
                OnRightClickEvent(Item);
            }
        }
        if (eventData.button == PointerEventData.InputButton.Left)
            {
                float timeSinceLastClick = Time.time - lastClickTime;
                if (timeSinceLastClick <= doubleClickTime)
                {
                    OnDoubleClick();
                }

                lastClickTime = Time.time;
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


