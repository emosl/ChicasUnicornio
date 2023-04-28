 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gadgets : MonoBehaviour
{
    public EquippableItem equippableItem;
    public GameObject player;
    public Inventory inventory;
    public GameManagerToby gameManager;
     public UnityEngine.Events.UnityEvent onItemPickedUp;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Character>().inventory;
        equippableItem.RandomizeBonuses(equippableItem.ItemName);
    }

    public void disappeargadgets()
    {
        inventory.AddItem(equippableItem);
        Debug.Log("Item added");
        //gameManager.GadgetCounter(equippableItem.ItemName);
        onItemPickedUp?.Invoke();
        Destroy(gameObject);

    }

   
}
