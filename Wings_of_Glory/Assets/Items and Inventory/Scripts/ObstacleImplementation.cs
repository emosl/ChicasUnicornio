
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//holaoooo

public class ObstacleImplementation : MonoBehaviour
{
    private TriggerValueAssigner triggerValueAssigner;

    public NotPassed notPassed;
    public GameObject itemNotRemovedPanel;
    public GameManagerToby gameManager;
    


    private void Start()
    {
        triggerValueAssigner = GetComponent<TriggerValueAssigner>();

        //  itemRemovedPanel.SetActive(false);
        // itemNotRemovedPanel.SetActive(false);
        itemNotRemovedPanel.SetActive(false);
        notPassed.Hide();
        
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

    private void CheckPlayerStats(Toby toby)
    {
        switch (triggerValueAssigner.triggerTag)
        {
            case TriggerValueAssigner.TriggerTag.Ice:
                if (toby.agility < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Agility");
                    gameManager.KillerSpriteCounter(triggerValueAssigner.triggerTag.ToString());
                    // itemRemovedPanel.SetActive(true);  
                    notPassed.Show(); 
                }
                else
                {
                    itemNotRemovedPanel.SetActive(true);

                }
                break;
            case TriggerValueAssigner.TriggerTag.Bomb:
                if (toby.shield < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Shield");

                    if (toby.shield < triggerValueAssigner.requiredValue)
                    {
                        // itemRemovedPanel.SetActive(true);
                        notPassed.Show(); 
                    }
                    else
                    {
                        itemNotRemovedPanel.SetActive(true);
                    }
                }
                break;
            case TriggerValueAssigner.TriggerTag.Water:
                if (toby.speed < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Speed");

                    if (toby.speed < triggerValueAssigner.requiredValue)
                    {
                        // itemRemovedPanel.SetActive(true);
                        notPassed.Show(); 
                    }
                    else
                    {
                        itemNotRemovedPanel.SetActive(true);
                    }
                }
                break;
            case TriggerValueAssigner.TriggerTag.Rock:
                if (toby.strength < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Strength");

                    if (toby.strength < triggerValueAssigner.requiredValue)
                    {
                        // itemRemovedPanel.SetActive(true);
                        notPassed.Show(); 
                    }
                    else
                    {
                        itemNotRemovedPanel.SetActive(true);
                    }
                }
                break;
        }
    }
}