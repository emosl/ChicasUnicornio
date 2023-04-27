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
    // public GameManagerToby gamemanagertoby;


    [SerializeField] TMP_Text ItemNameText; // Change this to TMP_Text // Change this to TMP_Text
    [SerializeField] TMP_Text ItemStatsText;

    private Inventory inventory;
    public GameManagerToby gameManagerToby;
    

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Character>().inventory;
       // gamemanagertoby.GadgetCounter(OnItemAdded);
        inventory.OnItemAdded += UpdatePanel;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        inventory.OnItemAdded -= UpdatePanel;
        
    }

//     public void UpdatePanel(Item addedItem)
// {
//     Debug.Log("UpdatePanel called with item: " + addedItem.ItemName);
//     if (addedItem is EquippableItem equippableItem)
//     {
//         Item = addedItem;
//         Show(equippableItem);
//     }
// }
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
        //Debug.Log("gamemanager gadget");
        //gameManagerToby.GadgetCounter(equippableItem.ToString());

        // Hide the panel after 3 seconds
        StartCoroutine(HidePanelAfterDelay(1f));
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

