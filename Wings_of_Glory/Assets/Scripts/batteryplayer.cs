//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryplayer : MonoBehaviour
{
    public int maxHealth=25;
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
    public Toby_stats toby_stats;

     
    

    public Healthbar strengthhealthbar;
    public Healthbar agilityhealthbar;
    public Healthbar speedhealthbar;
    public Healthbar lifehealthbar;
    public Healthbar shieldhealthbar;
    public TotalScore totalscore;
    //public Toby_stats toby_stats;
    

    // Start is called before the first frame update
    //Sets all the health bars to their minimum value
    void Start()
    {
        Debug.Log("current healtg" + maxHealth);
         Debug.Log("current strengtg" + maxStrengthHealth);
        currentHealth = maxHealth;
        lifehealthbar.SetMaxHealth(maxHealth);

        currentShieldHealth = minShieldHealth;
        shieldhealthbar.SetMinHealth(minShieldHealth);

        currentStrengthHealth = minStrengthHealth;
        strengthhealthbar.SetMinHealth(minStrengthHealth);

        currentAgilityHealth = minAgilityHealth;
        agilityhealthbar.SetMinHealth(minAgilityHealth);

        currentSpeedHealth = minSpeedHealth;
        speedhealthbar.SetMinHealth(minSpeedHealth);
        Debug.Log("Calling chosen armor");
        Debug.Log(toby_stats.chosenarmor);
        Debug.Log("Called chosen armor");
        toby_stats.chosenarmor=shieldchosen;
        armor();
        //red();
    }
    //The following function will be called when the player chooses their armor.

    public void armor(){
        string initialarmor=toby_stats.chosenarmor;
        int number=Random.Range(1,3);
        Debug.Log(number);
        if(number==1){
            blue();
        }
        if(number==2){
            red();
        }
        if(number==3){
            pink();
        }
    }
    //sets values for initial blue shield
    public void blue(){
        ChangeStrength(Random.Range(8,11));
        ChangeAgility(Random.Range(0,5));
        ChangeSpeed(Random.Range(4,7));
        ChangeShield(Random.Range(0,3)); 
    }
    //sets values for initial red shield
    public void red(){
        ChangeStrength(0);
        ChangeAgility(Random.Range(0,3));
        ChangeSpeed(Random.Range(4,8));
        ChangeShield(Random.Range(0,2)); 
    }
    //sets values for initial pink shield
    public void pink(){
        ChangeStrength(Random.Range(8,10));
        ChangeAgility(Random.Range(1,3));
        ChangeSpeed(Random.Range(5,8));
        ChangeShield(Random.Range(0,5)); 
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
    public void ChangeLife(int obst)
{
    
    currentHealth -= obst;
    Debug.Log("current health" + currentHealth);
    lifehealthbar.SetHealth(currentHealth);
}

}
