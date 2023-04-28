using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryplayer : MonoBehaviour
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


     
    

    public Healthbar strengthhealthbar;
    public Healthbar agilityhealthbar;
    public Healthbar speedhealthbar;
    public Healthbar lifehealthbar;
    public Healthbar shieldhealthbar;
    public TotalScore totalscore;
    

    // Start is called before the first frame update
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
    //The following function will be called when the player choses their armor.
    public void blue(){
        currentHealth=minHealth;
        strengthhealthbar.SetMinHealth(minHealth);
        agilityhealthbar.SetMinHealth(minHealth);
        speedhealthbar.SetMinHealth(minHealth);
        lifehealthbar.SetMinHealth(minHealth);
        shieldhealthbar.SetMinHealth(minHealth);
    }

    public void red(){
        currentHealth=minHealth;
        strengthhealthbar.SetMinHealth(minHealth);
        agilityhealthbar.SetMinHealth(minHealth);
        speedhealthbar.SetMinHealth(minHealth);
        lifehealthbar.SetMinHealth(minHealth);
        shieldhealthbar.SetMinHealth(minHealth);
    }

    public void pink(){
        currentHealth=minHealth;
        strengthhealthbar.SetMinHealth(minHealth);
        agilityhealthbar.SetMinHealth(minHealth);
        speedhealthbar.SetMinHealth(minHealth);
        lifehealthbar.SetMinHealth(minHealth);
        shieldhealthbar.SetMinHealth(minHealth);
    }

    
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

    // public void ChangeLife(int shield, int strength, int agility, int speed)
    // {
        
    //     currentHealth=points;
    //     if (currentHealth < 0){
    //        lifehealthbar.SetHealth(minHealth);
    //     }
    //     else
    //     {
    //        lifehealthbar.SetHealth(currentHealth);
    //     }
    // }
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
