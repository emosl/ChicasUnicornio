
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class gadgets : MonoBehaviour

// {
//     public EquippableItem equippableItem;
//     public GameObject player;
//     public GameObject[] invisible;
//     public Inventory inventory;
//     public ItemPickupPanel panel;
//     public InventoryInput inventoryInput;
   

//     void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player");
//         inventory = player.GetComponent<Character>().inventory;
//         equippableItem.RandomizeBonuses(equippableItem.ItemName);
//         panel = GameObject.Find("ItemPickupPanel").GetComponent<ItemPickupPanel>();
//         inventoryInput = FindObjectOfType<InventoryInput>();
        
//     } 


// public void disappeargadgets()
// {  
//     //panel.Show(equippableItem);
//     inventory.AddItem(equippableItem);
//     Destroy(gameObject);  
      
// }


// //     void Update()
// // {
// //     if (Input.GetKeyDown(KeyCode.E))
// //     {   
// //          panel.Hide();
         
         
// //         inventoryInput.CharacterPanelGameObject.SetActive(true); 
        
        
       
         
        
// //     }
// //     else if (Input.GetKeyDown(KeyCode.U))
// //     {    
// //         inventory.RemoveItem(equippableItem);
// //         panel.Hide();
        
           
// //     }
//    void Update()
//    {
//     if (Input.GetKeyDown(KeyCode.C))
//     {   
//          panel.Hide();    
//     }

//    }
// }



    
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
        gameManager.GadgetCounter(equippableItem.ItemName);

        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            panel.Hide();
        }
    }
}
