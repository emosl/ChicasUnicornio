using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerToby : MonoBehaviour
{
    public GameObject start_game;
    public GameObject Toby;
    public List<int> gadgetlist = new List<int>();
    public List<int> killerspritelist = new List<int>();

    public void GadgetCounter(string gadget)
    {
        if (gadget == "Carrot")
        {
            gadgetlist.Add(121);
        }
        else if (gadget == "FireShoe")
        {
            gadgetlist.Add(122);
        }
        else if (gadget == "Silver")
        {
            gadgetlist.Add(123);
        }
        else if (gadget == "SpikeShoe")
        {
            gadgetlist.Add(124);
        }
        else if (gadget == "Hairband")
        {
            gadgetlist.Add(125);
        }
        else if (gadget == "Manzana")
        {
            gadgetlist.Add(126);
        }
        else if (gadget == "Oro")
        {
            gadgetlist.Add(127);
        }
        else if (gadget == "Crown")
        {
            gadgetlist.Add(128);
        }
        else if (gadget == "Hat")
        {
            gadgetlist.Add(129);
        }
        else if (gadget == "Headband")
        {
            gadgetlist.Add(1201);
        }
        else if (gadget == "RollerShoe")
        {
            gadgetlist.Add(1202);
        }
        else if (gadget == "Bronze")
        {
            gadgetlist.Add(1203);
        }
    }

    public void KillerSpriteCounter(string killersprite)
    {
        if (killersprite == "Bomb")
        {
            killerspritelist.Add(131);
        }
        else if (killersprite == "Water")
        {
            killerspritelist.Add(132);
        }
        else if (killersprite == "Ice")
        {
            killerspritelist.Add(133);
        }
        else if (killersprite == "Rock")
        {
            killerspritelist.Add(134);
        }
    }

    void Start()
    {
        // Add code here to initialize the game state
    }

    void Update()
    {
        // Add code here to update the game state
    }
}
