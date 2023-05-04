//This script is used to display the item pickup panel when the player picks up an item. It also displays the item's name and stats.
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class ItemPickupPanel : MonoBehaviour
{
    public Item item;
    public Image itemImage;


    [SerializeField] TMP_Text ItemNameText; 
    [SerializeField] TMP_Text ItemStatsText;

    private Inventory inventory;
    public GameManagerToby gameManagerToby;
    

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Character>().inventory;
        inventory.OnItemAdded += UpdatePanel;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        inventory.OnItemAdded -= UpdatePanel;
        
    }

private IEnumerator HidePanelAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    Hide();
}

public void UpdatePanel(Item addedItem)
{
    if (addedItem is EquippableItem equippableItem)
    {
        Item = addedItem;
        Show(equippableItem);
        StartCoroutine(HidePanelAfterDelay(0.7f));
    }
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


    private StringBuilder sb = new StringBuilder();

    public void Show(EquippableItem item)
    {
        ItemNameText.text = item.ItemName;

        // ItemSlotText.text = item.EquipmentType.ToString();

        sb.Length = 0;

        AddStat(item.StrengthBonus, "Strength");
        AddStat(item.AgilityBonus, "Agility");
        AddStat(item.ShieldBonus, "Shield");
        AddStat(item.SpeedBonus, "Speed");

        ItemStatsText.text = sb.ToString();
        
       gameObject.SetActive(true);

    }
    public void Hide()
    { 
        Debug.Log("Hide function called");
        gameObject.SetActive(false);

    }


    public void HideTooltip()
    {
        gameObject.SetActive(false);

    }

    private void AddStat(float value, string statNames)
    {
        if (value != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine();
            if (value > 0)
                sb.Append("+");
            
            sb.Append(value);
            sb.Append(" ");
            sb.Append(statNames);
        }
        
    }
}

