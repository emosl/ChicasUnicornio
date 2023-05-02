using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobyBattle : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    public float groundCheckRadius = 1f;
    public LayerMask groundLayerMask;
    private bool isGrounded;
    private bool isMoving;
    public Toby toby;
    // public GameObject tobyObject;
    // public GameManagerToby gameManagerToby;
    public GameManagerFight gameManagerFight;
    public Transform objectToFollow;
    //  public float speed;
    // Start is called before the first frame update
    void Start()
    {
        // toby = GameObject.Find("Toby");
        animator.Play("walking");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         if (!isMoving)
        {
            rb.drag = 5f;
        }
        else
        {
            rb.drag = 3f;
        }

        rb.gravityScale = 3f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-APITest.speed, rb.velocity.y);
            animator.Play("walking");
            isMoving = true;
            
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Flip sprite when moving left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(APITest.speed, rb.velocity.y);
            animator.Play("walking");
            isMoving = true;
            
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Reset sprite rotation when moving right
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, APITest.strength), ForceMode2D.Impulse);
            transform.rotation = Quaternion.identity; // Reset sprite rotation when jumping
        }
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 offset = new Vector2(0f, -bounds.extents.y);
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + offset, groundCheckRadius, groundLayerMask);
        Attack();
        // Debug.Log("Toby's health is " + toby.agility);
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
            animator.Play("walking");
            // spriteRenderer.sprite = idleSprite;
        }
    }
    public void PushEnemy(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        animator.Play("attack");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         Debug.Log("OnTriggerEnter2D called with other: " + other.name);
        
         if (isGrounded && other.gameObject.CompareTag("loose"))
        {
            Debug.Log("loose");
            gameManagerFight.GameOver();
            // other.gameObject.GetComponent<Obstacle>().AskPermission();
            
        }
    }

}
