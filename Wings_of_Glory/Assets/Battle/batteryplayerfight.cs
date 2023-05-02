//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryplayerfight : MonoBehaviour
{
    public int maxHealth=53;
    public int minHealth=0;
    public int currentHealth;

    public int maxShieldHealth = 10;
    public int minShieldHealth = 0;
    public int currentShieldHealth;

    public int maxStrengthHealth = 18;
    public int minStrengthHealth = 8;
    public int currentStrengthHealth;

    public int maxAgilityHealth = 10;
    public int minAgilityHealth = 0;
    public int currentAgilityHealth;

    public int maxSpeedHealth = 15;
    public int minSpeedHealth = 5;
    public int currentSpeedHealth;
    public string shieldchosen;
    public Healthbarfight strengthhealthbar;
    public Healthbarfight agilityhealthbar;
    public Healthbarfight speedhealthbar;
    public Healthbarfight lifehealthbar;
    public Healthbarfight shieldhealthbar;
    //public Toby_stats toby_stats;
    

    // Start is called before the first frame update
    //Sets all the health bars to their minimum value
    void Start()
    {
        currentHealth=minHealth;

        currentShieldHealth = minShieldHealth;
        shieldhealthbar.SetMinHealth(minShieldHealth);

        currentStrengthHealth = minStrengthHealth;
        strengthhealthbar.SetMinHealth(minStrengthHealth);

        currentAgilityHealth = minAgilityHealth;
        agilityhealthbar.SetMinHealth(minAgilityHealth);

        currentSpeedHealth = minSpeedHealth;
        speedhealthbar.SetMinHealth(minSpeedHealth);
    }
    //The following function will be called when the player chooses their armor.

    
//Function that updates mentioned ability score by the amount specified.
    public void ChangeStrength(int points)
    {
        currentStrengthHealth = points;
        if (currentStrengthHealth < 0){
            strengthhealthbar.SetHealth(minStrengthHealth);
        }
        else
        {
            strengthhealthbar.SetHealth(currentStrengthHealth);
        }
    }
    //Function that updates mentioned ability score by the amount specified.
   public void ChangeAgility(int points)
    {
        currentAgilityHealth = points;
        

        if (currentAgilityHealth < 0){
            agilityhealthbar.SetHealth(minAgilityHealth);
        }
        else
        {
            agilityhealthbar.SetHealth(currentAgilityHealth);
        }

    }
//Function that updates mentioned ability score by the amount specified.
     public void ChangeSpeed(int points)
    {
        currentSpeedHealth=points;
        
       
        if (currentSpeedHealth < 0){
             speedhealthbar.SetHealth(minSpeedHealth);
        }
        else
        {
             speedhealthbar.SetHealth(currentSpeedHealth);
        }


    }
//Function that updates mentioned ability score by the amount specified.
    public void ChangeShield(int points)
    {
        currentShieldHealth=points;
        
        

        if (currentShieldHealth < 0){
            shieldhealthbar.SetHealth(minShieldHealth);
        }
        else
        {
            shieldhealthbar.SetHealth(currentShieldHealth);
        }
   
    }

    //This functions handles how toby's life will be calculated.
    public void ChangeLife(int shield, int strength, int agility, int speed)
{
    int positiveShield = Mathf.Max(0, shield);
    int positiveStrength = Mathf.Max(0, strength);
    int positiveAgility = Mathf.Max(0, agility);
    int positiveSpeed = Mathf.Max(0, speed);
    
    currentHealth = positiveShield + positiveStrength + positiveAgility + positiveSpeed;
    
    if (currentHealth < 0) {
        lifehealthbar.SetHealth(minHealth);
    }
    else {
        lifehealthbar.SetHealth(currentHealth);
    }
}

}

