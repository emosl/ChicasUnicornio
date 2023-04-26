using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryplayer : MonoBehaviour
{
    public int maxHealth=10;
    public int minHealth=0;
    public int currentHealth;
    

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
        strengthhealthbar.SetMinHealth(minHealth);
        agilityhealthbar.SetMinHealth(minHealth);
        speedhealthbar.SetMinHealth(minHealth);
        lifehealthbar.SetMinHealth(minHealth);
        shieldhealthbar.SetMinHealth(minHealth);
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeStrength(3);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeAgility(5);
        }
    }
//Function that updates mentioned ability score by the amount specified.
    public void ChangeStrength(int points)
    {
        currentHealth+=points;
        strengthhealthbar.SetHealth(currentHealth);
        if(points>0){
            //Changes the TotalScore of the game by the amount specified.
            Debug.Log("Strength increased by "+points);
            //other.gameObject.GetComponent<total>().disappeargadgets();
            totalscore.SetScore(points);
        }
        else{
            Debug.Log("Strength decreased by "+points);
            totalscore.SetScore(points);
        }
    }
    //Function that updates mentioned ability score by the amount specified.
   public void ChangeAgility(int points)
    {
        currentHealth+=points;
        agilityhealthbar.SetHealth(currentHealth);
        if(points>0){
            //Changes the TotalScore of the game by the amount specified.
            Debug.Log("Strength increased by "+points);
            totalscore.SetScore(points);
        }
        else{
            Debug.Log("Strength decreased by "+points);
        }
    }

     public void ChangeSpeed(int points)
    {
        currentHealth+=points;
        speedhealthbar.SetHealth(currentHealth);
        if(points>0){
            //Changes the TotalScore of the game by the amount specified.
            Debug.Log("Strength increased by "+points);
            totalscore.SetScore(points);
        }
        else{
            Debug.Log("Strength decreased by "+points);
        }
    }

    public void ChangeShield(int points)
    {
        currentHealth+=points;
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

    public void ChangeLife(int points)
    {
        currentHealth+=points;
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
