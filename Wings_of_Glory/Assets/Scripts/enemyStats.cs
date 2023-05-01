using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
    }

    // Update is called once per frame

    public void TakeDamage(int damage){
        currentHealth -= damage;
        // play hurt animation
        animator.SetTrigger("hurt");
        if(currentHealth <= 0){
            Die();
        }
    }
    void Die(){
    
        Debug.Log("Enemy died!");
        // Die animation
        animator.SetBool("IsDead",true);
         // disable the collider so the player can walk over the enemy
        //GetComponent<Collider2D>().enabled = false;
         // disable the enemy 
        this.enabled = false; 
    }
   
}
