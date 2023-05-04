// This script is used to assign a value to the trigger based on the tag. The value is used to determine the number of items that the player needs to collect to activate the trigger.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerValueAssigner : MonoBehaviour
{
    public enum TriggerTag { Ice, Bomb, Water, Rock }

    public TriggerTag triggerTag;
    public int requiredValue;

    void Start()
    {
        AssignValueBasedOnTag();
    }

    void AssignValueBasedOnTag()
    {
        switch (triggerTag)
        {
            case TriggerTag.Ice:
                requiredValue =  Random.Range(4, 7);
                break;
            case TriggerTag.Bomb:
                requiredValue = Random.Range(4, 7);
                break;
            case TriggerTag.Water:
                requiredValue = Random.Range(9, 12);
                break;
            case TriggerTag.Rock:
                requiredValue = Random.Range(12, 15);
                break;
        }
    }
}