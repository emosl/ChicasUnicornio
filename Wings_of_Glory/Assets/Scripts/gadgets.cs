
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gadgets : MonoBehaviour
{
    public EquippableItem equippableItem;
    public GameObject player;
    public GameObject[] invisible;
    public Inventory inventory;
    public ItemPickupPanel panel;
    public InventoryInput inventoryInput;
    public GameManagerToby gameManager;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Character>().inventory;
        equippableItem.RandomizeBonuses(equippableItem.ItemName);
        panel = GameObject.Find("ItemPickupPanel").GetComponent<ItemPickupPanel>();
        inventoryInput = FindObjectOfType<InventoryInput>();
    }

    public void disappeargadgets()
    {
        inventory.AddItem(equippableItem);
        
        Destroy(gameObject);
        gameManager.GadgetCounter(equippableItem.ItemName);

    }

   private void OnTriggerExit2D(Collider2D other)
    {
         Toby toby = other.GetComponent<Toby>();
        if (toby != null)
        {
            panel.Hide();
        }

    }
}
