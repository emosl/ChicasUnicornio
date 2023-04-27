// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using System.Text;

// public class NotPassed : MonoBehaviour
// {
//     public Item item;
//     public Image itemImage;


//     [SerializeField] TMP_Text ItemNameText; 
//     private Inventory inventory;
    

//     private void Start()
//     {
//         GameObject player = GameObject.FindGameObjectWithTag("Player");
//         inventory = player.GetComponent<Character>().inventory;
//         inventory.OnItemAdded += UpdatePanel;
//         gameObject.SetActive(false);
//     }


//     private void UpdatePanel(Item addedItem)
// {
//     Debug.Log("UpdatePanel called with item: " + addedItem.ItemName);
//     if (addedItem is EquippableItem equippableItem)
//     {
//         Item = addedItem;
//         Show(equippableItem);
//     }
// }


//     public Item Item
//     {
//         get { return item; }
//         set
//         {
//             item = value;
//             UpdateItemImage();
//         }
//     }

//     private void UpdateItemImage()
// {
//     if (itemImage == null)
//     {
//         return;
//     }

//     if (item == null)
//     {
//         itemImage.enabled = false;
//     }
//     else
//     {
//         itemImage.sprite = item.Icon;
//         itemImage.enabled = true;
//     }
// }


//     private StringBuilder sb = new StringBuilder();

//     public void Show(EquippableItem item)
//     {
//         ItemNameText.text = item.ItemName;

//         // ItemSlotText.text = item.EquipmentType.ToString();
        
//        gameObject.SetActive(true);

//     }
//     public void Hide()
//     { 
//         Debug.Log("Hide function called");
//         gameObject.SetActive(false);

//     }


   
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotPassed : MonoBehaviour
{
    public Item item;
    public Image itemImage;

    [SerializeField] private TMP_Text ItemNameText;

    private Inventory inventory;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        gameObject.SetActive(false);
    }



    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            UpdateItemImage();
        }
    }

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


    public void Show()
    {
        ItemNameText.text = item.ItemName;

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        Debug.Log("Hide function called");
        gameObject.SetActive(false);
    }

    
}
