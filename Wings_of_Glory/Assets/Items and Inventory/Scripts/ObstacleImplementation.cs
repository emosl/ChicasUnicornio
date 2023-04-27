
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// //holaoooo

public class ObstacleImplementation : MonoBehaviour
{
    private TriggerValueAssigner triggerValueAssigner;
    public StatPanel statsPanel;

    public GameObject itemNotRemovedPanel;
    public GameObject itemRemovedPanel;
    public GameManagerToby gameManagerToby;
    


    private void Start()
    {
        triggerValueAssigner = GetComponent<TriggerValueAssigner>();

         itemRemovedPanel.SetActive(false);
         itemNotRemovedPanel.SetActive(false);
       
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         Debug.Log("OnTriggerEnter called with other: " + other.name);
        Toby toby = other.GetComponent<Toby>();
        if (toby != null)
        {
            CheckPlayerStats(toby);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         Toby toby = other.GetComponent<Toby>();
        if (toby != null)
        {
            Hide();
        }

    }

    private void Hide()
    {
        itemRemovedPanel.SetActive(false);
        itemNotRemovedPanel.SetActive(false);
    }

    private void CheckPlayerStats(Toby toby)
    {
        switch (triggerValueAssigner.triggerTag)
        {
            case TriggerValueAssigner.TriggerTag.Ice:
                if (toby.agility < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Agility");
                    // gameManager.KillerSpriteCounter(triggerValueAssigner.triggerTag.ToString());
                    itemRemovedPanel.SetActive(true);  
                    
                }
                else
                {
                    itemNotRemovedPanel.SetActive(true);
                    //gameManagerToby.KillerSpriteCounter("Ice");


                }
                break;
            case TriggerValueAssigner.TriggerTag.Bomb:
                if (toby.shield < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Shield");

                    if (toby.shield < triggerValueAssigner.requiredValue)
                    {
                        itemRemovedPanel.SetActive(true);
                        
                    }
                    else
                    {
                        itemNotRemovedPanel.SetActive(true);
                        //gameManagerToby.KillerSpriteCounter("Shield");
                    }
                }
                break;
            case TriggerValueAssigner.TriggerTag.Water:
                if (toby.speed < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Speed");

                    if (toby.speed < triggerValueAssigner.requiredValue)
                    {
                        itemRemovedPanel.SetActive(true);
                       
                    }
                    else
                    {
                        itemNotRemovedPanel.SetActive(true);
                        //gameManagerToby.KillerSpriteCounter("Water");
                    }
                }
                break;
            case TriggerValueAssigner.TriggerTag.Rock:
                if (toby.strength < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Strength");

                    if (toby.strength < triggerValueAssigner.requiredValue)
                    {
                        itemRemovedPanel.SetActive(true);
                       
                    }
                    else
                    {
                        itemNotRemovedPanel.SetActive(true);
                        //gameManagerToby.KillerSpriteCounter("Rock");
                    }
                }
                break;
        }
        
    }
}

