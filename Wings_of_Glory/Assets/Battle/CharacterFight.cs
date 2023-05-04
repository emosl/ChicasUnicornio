//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 3, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This is a C# script defining a class called CharacterFight that inherits from MonoBehaviour.
public class CharacterFight : MonoBehaviour
{
    // These are public fields of type Stats.
    public Stats Strength;
    public Stats Agility;
    public Stats Shield;
    public Stats Speed;

    // These are private fields of type TobyBattle and batteryplayerfight, serialized so they can be viewed in the Inspector.
    [SerializeField] private TobyBattle toby;
    [SerializeField] private batteryplayerfight batteryPlayerfight;

    // This is a public field of type GameManagerFight.
    public GameManagerFight gameManagerFight;

    // This is a start method that is not currently being used due to all lines being commented out.
    public void start(){
        // batteryPlayerfight.ChangeAgility();
        // batteryPlayerfight.ChangeShield();
        // batteryPlayerfight.ChangeSpeed();
        // batteryPlayerfight.ChangeStrength();
        // batteryPlayerfight.ChangeLife(Shield.Value,Strength.Value,Agility.Value,Speed.Value);
    }
}
