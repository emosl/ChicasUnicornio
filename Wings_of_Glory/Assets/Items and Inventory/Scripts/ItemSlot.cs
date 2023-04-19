// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;


// public class ItemSlot : MonoBehaviour
// {
//     [SerializeField] Item Item;

//     private Item _item;

//     public Image Image
//     {
//         get { return _item;}
//         set {
//             _item =value;
//             if (_item == null)
//             {
//                 Image.enabled = false;
//             }
//             else
//             {
//                 Image.sprite = item.Icon;
//                 Image.enabled = true;
//             }
//         }
//     }

//     private void OnValidate()
//     {
//         if (Image == null)
//         {
//             Image = GetComponent<Image>();
//         }
//     }
    
// }

// using System.Collections;
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
