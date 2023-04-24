using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gadgets : MonoBehaviour
{
    public Toby jumpForce;
    public Toby speed;
    public Toby shield;
    public Toby agility;
    public EquippableItem equippableItem;
    public GameObject player;
    public GameObject[] invisible;
    //private Collider2D gadgetCollider;
    // Start is called before the first frame update
    void Start()
    {
        //jumpForce = FindObjectofType<Toby>();
        //gadgetCollider = GetComponent<Collider2D>();
        
    }
    public void disappeargadgets(){
        Instantiate(invisible[0], transform.position, Quaternion.identity);
    }
    
// //Tutorial for managing variables: https://www.google.com/search?q=how+to+use+a+variable+in+a+unity+script+in+another+script&rlz=1C5CHFA_enMX923MX923&oq=how+to+use+a+variable+in+a+unity+script+in+another+script&aqs=chrome..69i57j33i160l3.11705j0j4&sourceid=chrome&ie=UTF-8#fpstate=ive&vld=cid:bf91e53c,vid:aRmcN_79KYA
//     public void IncrementStrength1()
//     {
//         //Calculates how much strength
//         int rands = Random.Range(7, 8);
//         jumpForce.jumpForce+=rands;
//         if(jumpForce.jumpForce>10){
//             jumpForce.jumpForce=10;
//         }
//         //Calculates how much agility
//         int randa = Random.Range(5, 6);
//         agility.agility-=randa;
//         if(agility.agility<=0){
//             agility.agility=0;
//         }
//         //Calculates how much shield
//         int randsh = Random.Range(-2, 2);
//         shield.shield+=randsh;
//         if(shield.shield<=0){
//             shield.shield=0;
//         }
//         else if (shield.shield>10){
//             shield.shield=10;
//         }
//         //Calculates how much speed
//         int randsp = Random.Range(-2, 2);
//         speed.speed-=randsp;
//         if(speed.speed<=0){
//             speed.speed=0;
//         }
        
        
//     }

//     public void IncrementStrength2()
//     {
//         //Calculates how much strength
//         int rands = Random.Range(5, 6);
//         jumpForce.jumpForce+=rands;
//         if(jumpForce.jumpForce>10){
//             jumpForce.jumpForce=10;
//         }
//         //Calculates how much agility
//         int randa = Random.Range(3, 4);
//         agility.agility-=randa;
//         if(agility.agility<=0){
//             agility.agility=0;
//         }
//         //Calculates how much shield
//         int randsh = Random.Range(-2, 2);
//         shield.shield+=randsh;
//         if(shield.shield<=0){
//             shield.shield=0;
//         }
//         else if (shield.shield>10){
//             shield.shield=10;
//         }
//         //Calculates how much speed
//         int randsp = Random.Range(-2, 2);
//         speed.speed-=randsp;
//         if(speed.speed<=0){
//             speed.speed=0;
//         }
        
//     }

//     public void IncrementStrength3()
//     {
//         //Calculates how much strength
//         int rands = Random.Range(3, 4);
//         jumpForce.jumpForce+=rands;
//         if(jumpForce.jumpForce>10){
//             jumpForce.jumpForce=10;
//         }
//         //Calculates how much agility
//         int randa = Random.Range(1, 2);
//         agility.agility-=randa;
//         if(agility.agility<=0){
//             agility.agility=0;
//         }
//         //Calculates how much shield
//         int randsh = Random.Range(-2, 2);
//         shield.shield+=randsh;
//         if(shield.shield<=0){
//             shield.shield=0;
//         }
//         else if (shield.shield>10){
//             shield.shield=10;
//         }
//         //Calculates how much speed
//         int randsp = Random.Range(-2, 2);
//         speed.speed-=randsp;
//         if(speed.speed<=0){
//             speed.speed=0;
//         }

//     }

//     public void IncrementAgility1()
//     {
//         //Calculates how much agility
//         int randa = Random.Range(7, 8);
//         agility.agility+=randa;
//         if(agility.agility>10){
//             agility.agility=10;
//         }
//         //Calculates how much shield. It subtracts.
//         int randsh = Random.Range(5, 6);
//         shield.shield-=randsh;
//         if(shield.shield<=0){
//             shield.shield=0;
//         }
//         //Calculates how much strength
//         int rands = Random.Range(-2, 2);
//         jumpForce.jumpForce+=rands;
//         if(jumpForce.jumpForce<=0){
//             jumpForce.jumpForce=0;
//         }
//         else if(jumpForce.jumpForce>10){
//             jumpForce.jumpForce=10;
//         }
//         //Calculates how much speed
//         int randsp = Random.Range(-2, 2);
//         speed.speed-=randsp;
//         if(speed.speed<=0){
//             speed.speed=0;
//         }
//         else if(speed.speed>10){
//             speed.speed=10;
//         }   
//     }

//    public void IncrementAgility2()
//     {
//         //Calculates how much agility
//         int randa = Random.Range(5, 6);
//         agility.agility+=randa;
//         if(agility.agility>10){
//             agility.agility=10;
//         }
//         //Calculates how much shield. It subtracts.
//         int randsh = Random.Range(3, 4);
//         shield.shield-=randsh;
//         if(shield.shield<=0){
//             shield.shield=0;
//         }
//         //Calculates how much strength
//         int rands = Random.Range(-2, 2);
//         jumpForce.jumpForce+=rands;
//         if(jumpForce.jumpForce<=0){
//             jumpForce.jumpForce=0;
//         }
//         else if(jumpForce.jumpForce>10){
//             jumpForce.jumpForce=10;
//         }
//         //Calculates how much speed
//         int randsp = Random.Range(-2, 2);
//         speed.speed-=randsp;
//         if(speed.speed<=0){
//             speed.speed=0;
//         }
//         else if(speed.speed>10){
//             speed.speed=10;
//         }   
//     }

//     public void IncrementAgility3()
//     {
//         //Calculates how much agility
//         int randa = Random.Range(3, 4);
//         agility.agility+=randa;
//         if(agility.agility>10){
//             agility.agility=10;
//         }
//         //Calculates how much shield. It subtracts.
//         int randsh = Random.Range(1, 2);
//         shield.shield-=randsh;
//         if(shield.shield<=0){
//             shield.shield=0;
//         }
//         //Calculates how much strength
//         int rands = Random.Range(-2, 2);
//         jumpForce.jumpForce+=rands;
//         if(jumpForce.jumpForce<=0){
//             jumpForce.jumpForce=0;
//         }
//         else if(jumpForce.jumpForce>10){
//             jumpForce.jumpForce=10;
//         }
//         //Calculates how much speed
//         int randsp = Random.Range(-2, 2);
//         speed.speed-=randsp;
//         if(speed.speed<=0){
//             speed.speed=0;
//         }
//         else if(speed.speed>10){
//             speed.speed=10;
//         }   
//     }
    
//     public void IncrementShield1()
//     {
//         //Calculates how much shield
//         int randsh = Random.Range(7, 8);
//         shield.shield+=randsh;
//         if(shield.shield>10){
//             shield.shield=10;
//         }
//         //Calculates how much speed. It subtracts.
//         int randsp = Random.Range(5, 6);
//         speed.speed-=randsp;
//         if(speed.speed<=0){
//             speed.speed=0;
//         }
//         //Calculates how much strength
//         int rands = Random.Range(-2, 2);
//         jumpForce.jumpForce+=rands;
//         if(jumpForce.jumpForce<=0){
//             jumpForce.jumpForce=0;
//         }
//         else if(jumpForce.jumpForce>10){
//             jumpForce.jumpForce=10;
//         }
//         //Calculates how much agility
//         int randa = Random.Range(-2, 2);
//         agility.agility-=randa;
//         if(agility.agility<=0){
//             agility.agility=0;
//         }
//         else if(agility.agility>10){
//             agility.agility=10;
//         }   
//     }

//    public void IncrementShield2()
//     {
//        //Calculates how much shield
//         int randsh = Random.Range(5, 6);
//         shield.shield+=randsh;
//         if(shield.shield>10){
//             shield.shield=10;
//         }
//         //Calculates how much speed. It subtracts.
//         int randsp = Random.Range(3, 4);
//         speed.speed-=randsp;
//         if(speed.speed<=0){
//             speed.speed=0;
//         }
//         //Calculates how much strength
//         int rands = Random.Range(-2, 2);
//         jumpForce.jumpForce+=rands;
//         if(jumpForce.jumpForce<=0){
//             jumpForce.jumpForce=0;
//         }
//         else if(jumpForce.jumpForce>10){
//             jumpForce.jumpForce=10;
//         }
//         //Calculates how much agility
//         int randa = Random.Range(-2, 2);
//         agility.agility-=randa;
//         if(agility.agility<=0){
//             agility.agility=0;
//         }
//         else if(agility.agility>10){
//             agility.agility=10;
//         }   
//     }

//     public void IncrementShield3()
//     {
//         //Calculates how much shield
//         int randsh = Random.Range(3, 4);
//         shield.shield+=randsh;
//         if(shield.shield>10){
//             shield.shield=10;
//         }
//         //Calculates how much speed. It subtracts.
//         int randsp = Random.Range(1, 2);
//         speed.speed-=randsp;
//         if(speed.speed<=0){
//             speed.speed=0;
//         }
//         //Calculates how much strength
//         int rands = Random.Range(-2, 2);
//         jumpForce.jumpForce+=rands;
//         if(jumpForce.jumpForce<=0){
//             jumpForce.jumpForce=0;
//         }
//         else if(jumpForce.jumpForce>10){
//             jumpForce.jumpForce=10;
//         }
//         //Calculates how much agility
//         int randa = Random.Range(-2, 2);
//         agility.agility-=randa;
//         if(agility.agility<=0){
//             agility.agility=0;
//         }
//         else if(agility.agility>10){
//             agility.agility=10;
//         }   
//     }
    
//      public void IncrementSpeed1()
//     {
//         //Calculates how much speed
//         int randsp = Random.Range(7, 8);
//         speed.speed+=randsp;
//         if(speed.speed>10){
//             speed.speed=10;
//         }
//         //Calculates how much strength. It subtracts.
//         int rands = Random.Range(5, 6);
//         jumpForce.jumpForce-=rands;
//         if(jumpForce.jumpForce<=0){
//             jumpForce.jumpForce=0;
//         }
//         //Calculates how much shield
//         int randsh = Random.Range(-2, 2);
//         shield.shield+=randsh;
//         if(shield.shield<=0){
//             shield.shield=0;
//         }
//         else if(shield.shield>10){
//             shield.shield=10;
//         }
//         //Calculates how much agility
//         int randa = Random.Range(-2, 2);
//         agility.agility-=randa;
//         if(agility.agility<=0){
//             agility.agility=0;
//         }
//         else if(agility.agility>10){
//             agility.agility=10;
//         }   
//     }

//    public void IncrementSpeed2()
//     {
//        //Calculates how much speed
//         int randsp = Random.Range(7, 8);
//         speed.speed+=randsp;
//         if(speed.speed>10){
//             speed.speed=10;
//         }
//         //Calculates how much strength. It subtracts.
//         int rands = Random.Range(5, 6);
//         jumpForce.jumpForce-=rands;
//         if(jumpForce.jumpForce<=0){
//             jumpForce.jumpForce=0;
//         }
//         //Calculates how much shield
//         int randsh = Random.Range(-2, 2);
//         shield.shield+=randsh;
//         if(shield.shield<=0){
//             shield.shield=0;
//         }
//         else if(shield.shield>10){
//             shield.shield=10;
//         }
//         //Calculates how much agility
//         int randa = Random.Range(-2, 2);
//         agility.agility-=randa;
//         if(agility.agility<=0){
//             agility.agility=0;
//         }
//         else if(agility.agility>10){
//             agility.agility=10;
//         }   
//     }

//     public void IncrementSpeed3()
//     {
//         //Calculates how much speed
//         int randsp = Random.Range(7, 8);
//         speed.speed+=randsp;
//         if(speed.speed>10){
//             speed.speed=10;
//         }
//         //Calculates how much strength. It subtracts.
//         int rands = Random.Range(5, 6);
//         jumpForce.jumpForce-=rands;
//         if(jumpForce.jumpForce<=0){
//             jumpForce.jumpForce=0;
//         }
//         //Calculates how much shield
//         int randsh = Random.Range(-2, 2);
//         shield.shield+=randsh;
//         if(shield.shield<=0){
//             shield.shield=0;
//         }
//         else if(shield.shield>10){
//             shield.shield=10;
//         }
//         //Calculates how much agility
//         int randa = Random.Range(-2, 2);
//         agility.agility-=randa;
//         if(agility.agility<=0){
//             agility.agility=0;
//         }
//         else if(agility.agility>10){
//             agility.agility=10;
//         }   
//     }
    
    
//     void Update()
//     {
        
//     }
 }
