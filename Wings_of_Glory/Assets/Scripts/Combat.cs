using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private System.Random rnd = new System.Random();
    public int attackDamage;

    void Awake()
    {
        attackDamage = rnd.Next(20, 40);
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetKeyDown(KeyCode.Space))
    {
        Attack();
    }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitenemey = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

        foreach(Collider2D enemey in hitenemey)
        {
            enemey.GetComponent<enemyStats>().TakeDamage(attackDamage);
        }
    }
void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}