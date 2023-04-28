// Toby movements and animation in during the fight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;
using UnityEngine.SceneManagement;
[System.Serializable]

public class Toby_stats2
{
    public Vector3 initialPosition2;
    public Vector3 savedPosition2;
}


public class TobyFighting : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public GameObject player;  
    public Transform objectToFollow;
    

public float speed = 20f;
    public float groundCheckRadius = 1f;
    public LayerMask groundLayerMask;

    private bool isGrounded;
    private bool isMoving;

    public Sprite idleSprite;
    public Sprite leapSprite;
    //public GameObject[] levels;

    private Toby_stats2 toby_stats2 = new Toby_stats2();

    public Vector3 initialPosition2; // added variable to store initial position

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition2 = transform.position; // save the initial position of the sprite
        animator.Play("idle");
        toby_stats2.initialPosition2 = transform.position;
        toby_stats2.savedPosition2 = transform.position;
        string jsonStats = PlayerPrefs.GetString("toby_stats", JsonUtility.ToJson(toby_stats2));
        Debug.Log(jsonStats);
        toby_stats2 = JsonUtility.FromJson<Toby_stats2>(jsonStats);
        transform.position = toby_stats2.savedPosition2;
        PlayerPrefs.DeleteAll();
        

        player = GameObject.FindGameObjectWithTag("Player");
        // player.GetComponent<CamerMove>().Start();
    }

    void Update()
    {
        // Check if sprite is grounded
        // PlayerPrefs.DeleteAll();
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 offset = new Vector2(0f, -bounds.extents.y);
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + offset, groundCheckRadius, groundLayerMask);

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

    
}
