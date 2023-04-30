 
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
    public List<int> gadgetlist = new List<int>();

    [SerializeField] APITest api;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Character>().inventory;
        equippableItem.RandomizeBonuses(equippableItem.ItemName);
    }
//Makes gadgets dissapear and equips them on contact. This function also calls gadgetmanager for the API
    public void disappeargadgets()
    {
        inventory.AddItem(equippableItem);
        Debug.Log("Item added");
        string gadgetname=equippableItem.ToString();
        onItemPickedUp?.Invoke();
        Destroy(gameObject);
        gadgetmanager(gadgetname);
    }

    //This function stores the gadget_id in a list for the API
    public void gadgetmanager(string gadget){
        Debug.Log(gadget);
        if (gadget == "Carrot (EquippableItem)")
        {
            api.UpdateGadget(121);
            Debug.Log("Added gadget" + gadget);
            gadgetlist.Add(121);
            
        }
        else if (gadget == "Fire Shoe (EquippableItem)")
        {
            gadgetlist.Add(122);
            api.UpdateGadget(122);
            Debug.Log("Added gadget" + gadget);
        }
        else if (gadget == "Plata (EquippableItem)")
        {
            gadgetlist.Add(123);
            api.UpdateGadget(123);
            Debug.Log("Added gadget" + gadget);
        }
        else if (gadget == "Spike Shoe (EquippableItem)")
        {
            gadgetlist.Add(124);
            api.UpdateGadget(124);
            Debug.Log("Added gadget" + gadget);
        }
        else if (gadget == "Hairband (EquippableItem)")
        {
            gadgetlist.Add(125);
            api.UpdateGadget(125);
            Debug.Log("Added gadget" + gadget);
        }
        else if (gadget == "Manzana (EquippableItem)")
        {
            api.UpdateGadget(126);
            Debug.Log("Added gadget" + gadget);
            gadgetlist.Add(126);
        }
        else if (gadget == "Oro (EquippableItem)")
        {
            gadgetlist.Add(127);
            api.UpdateGadget(127);
            Debug.Log("Added gadget" + gadget);
        }
        else if (gadget == "Crown (EquippableItem)")
        {
            gadgetlist.Add(128);
            api.UpdateGadget(128);
            Debug.Log("Added gadget" + gadget);
        }
        else if (gadget == "Hat (EquippableItem)")
        {
            gadgetlist.Add(129);
            api.UpdateGadget(129);
            Debug.Log("Added gadget" + gadget);
        }
        else if (gadget == "Headband (EquippableItem)")
        {
            gadgetlist.Add(1201);
            api.UpdateGadget(1201);
            Debug.Log("Added gadget" + gadget);
        }
        else if (gadget == "Roller Shoe (EquippableItem)")
        {
            gadgetlist.Add(1202);
            api.UpdateGadget(1202);
            Debug.Log("Added gadget" + gadget);
        }
        else if (gadget == "Bronze (EquippableItem)")
        {
            gadgetlist.Add(1203);
            api.UpdateGadget(1203);
            Debug.Log("Added gadget" + gadget);
        }
        else if (gadget == "Pastel (EquippableItem)")
        {
            gadgetlist.Add(1204);
            api.UpdateGadget(1204);
            Debug.Log("Added gadget" + gadget);
        }
        else{
            Debug.Log("Could not add gadget" + gadget+ "Check for errors in syntax");
        }
    }

    // public UpdateGadget()
    // {
    //     api.UpdateGadget(int gadget);
    // }
   
}
