using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryplayer : MonoBehaviour
{
    public int maxHealth=10;
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
        //Sets the current health to the max health in all of the batteries.
        // currentHealth=maxHealth;
        // strengthhealthbar.SetMaxHealth(maxHealth);
        // agilityhealthbar.SetMaxHealth(maxHealth);
        // speedhealthbar.SetMaxHealth(maxHealth);
        // lifehealthbar.SetMaxHealth(maxHealth);
        // shieldhealthbar.SetMaxHealth(maxHealth);

        currentHealth=minHealth;
        // strengthhealthbar.SetMinHealth(minHealth);
        // agilityhealthbar.SetMinHealth(minHealth);
        // speedhealthbar.SetMinHealth(minHealth);
        // lifehealthbar.SetMinHealth(minHealth);
        // shieldhealthbar.SetMinHealth(minHealth);

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
    void blue(){
        currentHealth=minHealth;
        strengthhealthbar.SetMinHealth(minHealth);
        agilityhealthbar.SetMinHealth(minHealth);
        speedhealthbar.SetMinHealth(minHealth);
        lifehealthbar.SetMinHealth(minHealth);
        shieldhealthbar.SetMinHealth(minHealth);
    }

    void red(){
        currentHealth=minHealth;
        strengthhealthbar.SetMinHealth(minHealth);
        agilityhealthbar.SetMinHealth(minHealth);
        speedhealthbar.SetMinHealth(minHealth);
        lifehealthbar.SetMinHealth(minHealth);
        shieldhealthbar.SetMinHealth(minHealth);
    }

    void pink(){
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
        
        

        // if(points>0){
        //     //Changes the TotalScore of the game by the amount specified.
        //     Debug.Log("Strength increased by "+points);
        //     //other.gameObject.GetComponent<total>().disappeargadgets();
        //     totalscore.SetScore(points);
        // }
        // else{
        //     Debug.Log("Strength decreased by "+points);
        //     totalscore.SetScore(points);
        // }
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
        // if(points>0){
        //     //Changes the TotalScore of the game by the amount specified.
        //     Debug.Log("Strength increased by "+points);
        //     totalscore.SetScore(points);
        // }
        // else{
        //     Debug.Log("Strength decreased by "+points);
        // }
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

        // if(points>0){
        //     //Changes the TotalScore of the game by the amount specified.
        //     Debug.Log("Strength increased by "+points);
        //     totalscore.SetScore(points);
        // }
        // else{
        //     Debug.Log("Strength decreased by "+points);
        // }
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
        // if(points>0){
        //     //Changes the TotalScore of the game by the amount specified.
        //     Debug.Log("Strength increased by "+points);
        //     totalscore.SetScore(points);
        // }
        // else{
        //     Debug.Log("Strength decreased by "+points);
        // }
    }

    public void ChangeLife(int points)
    {
        currentHealth=points;
        shieldhealthbar.SetHealth(currentHealth);
        if(points>0){
            //Changes the TotalScore of the game by the amount specified.
            Debug.Log("Strength increased by "+points);
            totalscore.SetScore(points);
        }
        else{
            Debug.Log("Strength decreased by "+points);
        }
    }
}
