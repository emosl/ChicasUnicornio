//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MulaBattle : MonoBehaviour
{
    public Animator animator;
    public float groundCheckRadius = 1f;
    public LayerMask groundLayerMask;

    private bool isGrounded;
    private bool isMoving;

    public Transform objectToFollow;
    // public float speed;
    public GameManagerFight gameManagerFight;
    // public GameManagerFight muleFight;
    public TobyBattle tobyBattle;
    public bool dead;
    // Start is called before the first frame update
    public void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        animator.Play("mula_caminando");
         dead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 offset = new Vector2(0f, -bounds.extents.y);
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + offset, groundCheckRadius, groundLayerMask);
        // transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, speed * Time.deltaTime);
    }
    public void PushMule(float speed)
    {
        //  Debug.Log("mule speed: " + muleFight.mule_speed);
       transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, speed * Time.deltaTime);
       transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        // animator.Play("mula_atack");
        if(dead!=true)
            {
                animator.Play("attack");
            }
            else
            {
                animator.Play("dead");
            }
        // muleFight.MuleSum = muleFight.MuleSum - 20;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
         Debug.Log("OnTriggerEnter2D called with other: " + other.name);
        
         if (isGrounded && other.gameObject.CompareTag("win"))
        {
            Debug.Log("win");
            // animator.Play("mula_muerta");
            animator.Play("mula_bien_muerta");
            dead = true;
            StartCoroutine(WaitTransform());
            tobyBattle.animator.Play("transform");
            // StopAllCoroutines();
            StartCoroutine(WaitWin());
            // other.gameObject.GetComponent<Obstacle>().AskPermission();
            
        }
    }

    IEnumerator WaitWin()
    {
        yield return new WaitForSeconds(6f);
        gameManagerFight.WinGame();
    }
    IEnumerator WaitLose()
    {
        yield return new WaitForSeconds(2f);
        gameManagerFight.GameOver();
    }
    IEnumerator WaitTransform()
    {
        yield return new WaitForSeconds(3f);
        tobyBattle.animator.Play("transform");
        animator.Play("mula_muerta");
    }

    
}
