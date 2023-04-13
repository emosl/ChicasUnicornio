
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;

public class Toby : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public float speed = 5f;
    public float jumpForce = 10f;
    public float groundCheckRadius = 1f;
    public LayerMask groundLayerMask;

    private bool isGrounded;
    private bool isMoving;

    public Sprite idleSprite;
    public Sprite leapSprite;
    public GameObject[] levels;

    public Vector3 initialPosition; // added variable to store initial position

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.position; // save the initial position of the sprite
        animator.Play("idle");
    }

    void Update()
    {
        // Check if sprite is grounded
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 offset = new Vector2(0f, -bounds.extents.y);
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + offset, groundCheckRadius, groundLayerMask);

    // Collider2D barrier = Physics2D.Overlapbox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
    // Collider2D barrier = Physics2D.OverlapArea(destination - Vector3.one * 0.5f, destination + Vector3.one * 0.5f, LayerMask.GetMask("Barrier"));

        // Move left or right based on user input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animator.Play("walking");
            isMoving = true;
            spriteRenderer.sprite = leapSprite;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Flip sprite when moving left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.Play("walking");
            isMoving = true;
            spriteRenderer.sprite = leapSprite;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Reset sprite rotation when moving right
        }

    // Stop moving left or right when arrow key is released
    if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.Space))
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
        isMoving = false;
        animator.Play("idle");
        spriteRenderer.sprite = idleSprite;
    }

   
        // Jump if sprite is grounded and user presses the space key
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            transform.rotation = Quaternion.identity; // Reset sprite rotation when jumping
        }


        // Add some drag to slow the sprite down when not moving
        if (!isMoving)
        {
            rb.drag = 5f;
        }
        else
        {
            rb.drag = 3f;
        }
    }

    void FixedUpdate()
    {
        // Adjust gravity scale to make the sprite fall slower
        rb.gravityScale = 3f;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            transform.position = initialPosition; // reset the position of the sprite to the initial position
        }
        else if (other.gameObject.CompareTag("LevelChange"))
        {
            int rand = Random.Range(0, levels.Length);
            transform.position = levels[rand].transform.position;
            Destroy(levels[rand]); // remove the selected level from the levels array
        }
    }
}

