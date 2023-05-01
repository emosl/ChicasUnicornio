using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobyBattle : MonoBehaviour
{
    
    public Animator animator;
    public Toby toby;
    public GameObject tobyObject;
    public GameManagerToby gameManagerToby;
    // Start is called before the first frame update
    void Start()
    {
        tobyObject = GameObject.Find("Toby");
    }

    // Update is called once per frame
    void Update()
    {
        
        Attack();
        Debug.Log("Toby's health is " + toby.agility);
    }

    public void Attack()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // rb.velocity = new Vector2(-speed, rb.velocity.y);
            animator.Play("attack");
            // isMoving = true;
            // spriteRenderer.sprite = leapSprite;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Flip sprite when moving left
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            // rb.velocity = new Vector2(0f, rb.velocity.y);
            // isMoving = false;
            animator.Play("idle");
            // spriteRenderer.sprite = idleSprite;
        }
    }


}
