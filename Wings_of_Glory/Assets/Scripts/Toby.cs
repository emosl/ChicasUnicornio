using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;


public class Toby : MonoBehaviour
{
   
   private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float speed = 5f;
    public float jumpForce = 10f;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayerMask;

    public Vector3 initialPosition; // added variable to store initial position

private bool isGrounded;
private bool isMoving;

public Sprite idleSprite;
public Sprite leapSprite;
public GameObject[] levels;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    initialPosition = transform.position; // save the initial position of the sprite
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
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        isMoving = true;
        spriteRenderer.sprite = leapSprite;
        transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Flip sprite when moving left
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        isMoving = true;
        spriteRenderer.sprite = leapSprite;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Reset sprite rotation when moving right
    }

    // Stop moving left or right when arrow key is released
    if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.Space))
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
        isMoving = false;
        spriteRenderer.sprite = idleSprite;
    }

    // Jump if sprite is grounded and user presses the space key
    if (isGrounded && Input.GetKeyDown(KeyCode.Space))
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        spriteRenderer.sprite = leapSprite;
        transform.rotation = Quaternion.identity; // Reset sprite rotation when moving right

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

      if (other.gameObject.CompareTag("LevelChange"))
    {
        int rand = Random.Range(0, levels.Length);
        transform.position = levels[rand].transform.position;
       // Destroy(levels[rand]); remove the selected level from the scene
        //levels.RemoveAt(rand); remove the selected level from the levels list
        Destroy(levels[rand]); // remove the selected level from the levels array
    }
}



    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {

     
    //     if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
    //         transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    //         Move(Vector3.up);
    //     }
    //     else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
    //         transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    //         Move(Vector3.down);
    //     }
    //     else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
    //        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    //         Move(Vector3.left);
    //     }
    //     else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
    //         transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    //         Move(Vector3.right);
    //     }
        
    // }
    // private void Move(Vector3 direction)
    // {
    //     // Vector3 destination = transform.position + direction; 
    //     transform.position += direction;
        // Collider2D barrier = Physics2D.Overlapbox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        // Collider2D barrier = Physics2D.OverlapArea(destination - Vector3.one * 0.5f, destination + Vector3.one * 0.5f, LayerMask.GetMask("Barrier"));
        // Collider2D platform = Physics2D.OverlapArea(destination - Vector3.one * 0f, destination + Vector3.one * 0f, LayerMask.GetMask("Platform"));
        // Collider2D obstacle = Physics2D.OverlapArea(destination - Vector3.one * 0f, destination + Vector3.one * 0f, LayerMask.GetMask("Obstacle"));
        // if(barrier != null){
        //      return;
        //    }
        // if(platform != null){
        //     transform.SetParent(platform.transform);
        // } else{
        //     transform.SetParent(null);
        // }

        // if(obstacle != null && platform == null){
        //     transform.position=destination; 
        //     Death();
        // }else
        // {
        //     if(destination.y > farthestRow){
        //         farthestRow = destination.y;
        //     }
        //     FindObjectOfType<GameManager>().AdvancedRow();
        //     StartCoroutine(Leap(destination));
        // }

    // }
}

public static class GameObjectExtensions
{
    public static void RemoveComponent(this GameObject gameObject, System.Type type)
    {
        Component component = gameObject.GetComponent(type);
        if (component != null)
        {
            Object.Destroy(component);
        }
    }
}
