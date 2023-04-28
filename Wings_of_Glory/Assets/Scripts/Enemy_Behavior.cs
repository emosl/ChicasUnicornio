using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    public Transform target;
    public LayerMask targetMask;
    public float targetLength;
    public float attackRange;
    public float moveSpeed;
    public float timeBetweenAttacks;
    private RaycastHit2D hit;
    private GameObject targetObject;
    private Animator animator;
    private float distanceToTarget;
    private float distance;
    private bool attackMode;
    private bool inrange;
    private bool cooling;
    private float time;
    private float intTimer;

    void Awake()
    {
        intTimer = time;
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(inrange)
        {
            hit = Physics2D.Raycast(target.position, Vector2.left, targetLength, targetMask);
            RaycastDebugger();
        }
   
        if(hit.collider != null)
        {
             EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inrange = false;
        }
        if(inrange==false)
        {
            animator.SetBool("canWalk", false);
            StopAttack();
        }
     }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inrange =true;
        }
    }
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if(distance > attackRange)
        {
            Move();
            StopAttack();
        }
        else if(attackRange >= distance && cooling == false)
        {
            Attack();
        }
        if(cooling)
        {
            animator.SetBool("attack", false);
        }
    }
    void Move()
    {
        animator.SetBool("canWalk", true);
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    void Attack()
    {
        time = intTimer;
        attackMode = true;
        animator.SetBool("canWalk", false);
        animator.SetBool("attack", true);
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("attack", false);
    }
    void RaycastDebugger()
    {
        if(distance > attackRange)
        {
            Debug.DrawRay(target.position, Vector2.left * targetLength, Color.red);
        }
        else if(attackRange > distance)
        {
             Debug.DrawRay(target.position, Vector2.left * targetLength, Color.green);
        }
       
    }
}
