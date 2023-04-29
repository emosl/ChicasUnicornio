/// Code for enemy behavior during final battle 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;

   // This method is called when the script instance is being loaded.
   void Awake()
   {
       // Copy the value of the 'timer' variable to 'intTimer'.
       intTimer = timer;
   
       // Get a reference to the Animator component attached to this GameObject.
       anim = GetComponent<Animator>();
   }

    void Update () {
        if (inRange)
        {
        hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
        RaycastDebugger();
    }

        //When Player is detected
        if(hit.collider != null)
        {
        EnemyLogic();
        Debug.Log("Player in range2");
        }
    // when the player is not inside the enemy's attack range
    else if(hit.collider == null)
    {
        inRange = false;
    }
    // Action of the enemy when the player is not detected
    if(inRange == false)
    {
        anim.SetBool("canWalk", false);
        StopAttack();
    }
   }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

// Enemy's attack logic
   void EnemyLogic(){
    // Distance between enemy and player
    distance = Vector2.Distance(transform.position, target.transform.position);
    //When the player is not inside the enemy's attack range
    if(distance > attackDistance)
    {
        Move();
        StopAttack();
    }
    // When the player is inside the enemy's attack range and can fight (is not in cooling mode)
    else if (attackDistance >= distance && cooling == false)
    {
        Attack();

   }
   //When the enemy can not fight
    if(cooling)
    {
        Cooldown();
        anim.SetBool("Attack", false);
    }
   }
   // Enemys actions when attacking
   void Move()
   {
            anim.SetBool("canWalk", true);
    
    if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
    {
        // Gets the position of the player
        Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
        // Moves the enemy towards the player
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // Sets the animation to walk
        anim.SetBool("canWalk", true);
    }
   }
   void Attack()
   {
        // Resets the timer
         timer = intTimer;
         // Sets the enemy to attack mode
         attackMode = true;
         // Sets the animation to attack and to stop walking
         anim.SetBool("canWalk", false);
         anim.SetBool("Attack", true);
         GetComponent<TobyStats>().TakeDamage(10);
   }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

   void StopAttack()
   {
       cooling = false;
       attackMode = false;
       anim.SetBool("Attack", false);
   }
   

   //Shows raycast in the scene view and the funcionlity
   void RaycastDebugger()
   {
       if(distance > attackDistance)
       {
           Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
       } 
        else if(attackDistance > distance)
       {
           Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
       }
   }

    public void TriggerCooling()
    {
        cooling = true;
    }
}

   
