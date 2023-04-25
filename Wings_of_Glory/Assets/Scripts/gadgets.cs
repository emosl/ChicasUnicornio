using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gadgets : MonoBehaviour
{
    public EquippableItem equippableItem;
    public GameObject player;
    public GameObject[] invisible;
    Inventory inventory;

    void Start()
    {
         
    
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Character>().inventory;

         equippableItem.RandomizeBonuses(equippableItem.ItemName);
        


        
    }
    public void disappeargadgets(){      
        inventory.AddItem(equippableItem);
        Destroy(gameObject);
    }
    
}


