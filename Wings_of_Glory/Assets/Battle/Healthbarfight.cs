//Wings of Glory script. This script is used in the implementation of Wings of Glory
//authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//THis script control the movemento of the ability bars as Toby plays the game
public class Healthbarfight : MonoBehaviour
{
    public Slider slider;
     [SerializeField] APITest api;
    // Start is called before the first frame update
    
    //THis function is the one that is called when a change is made.
    public void SetHealth(int health)
    {
        
        slider.value = health ;
        Debug.Log("Health: " + health);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetMinHealth(int health)
    {
        slider.minValue = health;
        slider.value = health;
    }
}