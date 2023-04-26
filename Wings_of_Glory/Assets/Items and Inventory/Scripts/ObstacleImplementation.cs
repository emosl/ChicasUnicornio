
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//hola

public class ObstacleImplementation : MonoBehaviour
{
    private TriggerValueAssigner triggerValueAssigner;

    private void Start()
    {
        triggerValueAssigner = GetComponent<TriggerValueAssigner>();
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
            Debug.Log("Checking " + triggerValueAssigner.triggerTag + " - Required value: " + triggerValueAssigner.requiredValue + " - Player value: " + toby.agility);

                if (toby.agility < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Agility");
                }
                break;
            case TriggerValueAssigner.TriggerTag.Bomb:
            Debug.Log("Checking " + triggerValueAssigner.triggerTag + " - Required value: " + triggerValueAssigner.requiredValue + " - Player value: " + toby.shield);

                if (toby.shield < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Shield");
                }
                break;
            case TriggerValueAssigner.TriggerTag.Water:
            Debug.Log("Checking " + triggerValueAssigner.triggerTag + " - Required value: " + triggerValueAssigner.requiredValue + " - Player value: " + toby.speed);

                if (toby.speed < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Speed");
                }
                break;
            case TriggerValueAssigner.TriggerTag.Rock:
            Debug.Log("Checking " + triggerValueAssigner.triggerTag + " - Required value: " + triggerValueAssigner.requiredValue + " - Player value: " + toby.strength);

                if (toby.strength < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Strength");
                }
                break;
        }
    }
}
