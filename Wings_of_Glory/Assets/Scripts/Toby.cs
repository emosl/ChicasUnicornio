// joleping
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Toby_stats 
{
    public Vector3 initialPosition;
    public Vector3 savedPosition;
}


public class Toby : MonoBehaviour
{
    private Rigidbody2D rb;
    private Preguntas ButtonPressed;
    private Preguntas button;
    private Obstacle obstacleCollider;
    
    private Obstacle obstacle;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public Obstacle currentObstacle;
    public GameObject player;  
    private gadgets gadgetcollider;
    public ItemPickupPanel pickupPanel;


   [SerializeField] private Character character;
   private batteryplayer bp;


    public int speed = 5;

    public int strength = 10;

    public int shield=0;

    public int agility=0;


    public float groundCheckRadius = 1f;
    public LayerMask groundLayerMask;

    private bool isGrounded;
    private bool isMoving;

    public Sprite idleSprite;
    public Sprite leapSprite;
    public GameObject[] levels;

    private Toby_stats toby_stats = new Toby_stats();
    //public Vector3 initialPosition; // added variable to store initial position

    public Vector3 initialPosition; // added variable to store initial position

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.position; // save the initial position of the sprite
        animator.Play("idle");
        toby_stats.initialPosition = transform.position;
        toby_stats.savedPosition = transform.position;
        button = FindObjectOfType<Preguntas>();
        obstacleCollider = FindObjectOfType<Obstacle>();

         // save the initial position of the sprite
        string jsonStats = PlayerPrefs.GetString("toby_stats", JsonUtility.ToJson(toby_stats));
        Debug.Log(jsonStats);
        toby_stats = JsonUtility.FromJson<Toby_stats>(jsonStats);
        transform.position = toby_stats.savedPosition;
        PlayerPrefs.DeleteAll();

        pickupPanel = FindObjectOfType<ItemPickupPanel>();


        
        

        player = GameObject.FindGameObjectWithTag("Player");
        // player.GetComponent<CamerMove>().Start();
    }

    void Update()
    {
        speed = Mathf.Clamp(speed, 5, 15);
        shield = Mathf.Clamp(shield, 0, 10);
        agility = Mathf.Clamp(agility, 0, 10);
        strength = Mathf.Clamp(strength, 8, 18);
        // Check if sprite is grounded
        PlayerPrefs.DeleteAll();
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
            rb.AddForce(new Vector2(0f, strength), ForceMode2D.Impulse);
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

    //OnTriggerEnter2D is called when the Collider2D other enters the trigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
         Debug.Log("OnTriggerEnter2D called with other: " + other.name);
        
         if (isGrounded && other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Obstaccle");
            other.gameObject.GetComponent<Obstacle>().AskPermission();
            
        }
        else if (other.gameObject.CompareTag("LevelChange"))
        {
            int rand = Random.Range(0, levels.Length);
            transform.position = levels[rand].transform.position;
            Destroy(levels[rand]); // remove the selected level from the levels array
        }
        else if (other.gameObject.CompareTag("Dungeon"))
        {
            // SceneManager.LoadScene("frogger_dungeon");
            toby_stats.savedPosition = transform.position; // save the current position of the sprite
            string jsonStats = JsonUtility.ToJson(toby_stats); //convertir a json
            PlayerPrefs.SetString("toby_stats", jsonStats); //guarda posición
            other.gameObject.GetComponent<Dungeon>().AskPermissionD();
        }
        else if (other.gameObject.CompareTag("Food")) //This option is activated when Toby gets a strength gadget.
        {
            Debug.Log("Food");
            // other.gameObject.GetComponent<gadgets>().disappeargadgets(); 
            
            other.gameObject.GetComponent<gadgets>().disappeargadgets();
    
        }
        else if (other.gameObject.CompareTag("HeadBand")) //This option is activated when Toby gets a strength gadget.
        {
            other.gameObject.GetComponent<gadgets>().disappeargadgets(); 
        }
        else if (other.gameObject.CompareTag("Horseshoe")) //This option is activated when Toby gets a strength gadget.
        {
            
            other.gameObject.GetComponent<gadgets>().disappeargadgets(); 
        }
        else if (other.gameObject.CompareTag("Metal")) //This option is activated when Toby gets a strength gadget.
        {
            
            other.gameObject.GetComponent<gadgets>().disappeargadgets(); 
        }
      
        
    }

   

    public void PermissionGranted()
    {
        if (currentObstacle != null)
        {
            // currentObstacle.gameObject.GetComponent<Obstacle>().MakeTriggersForObstacleColliders();
            currentObstacle = null;
        }
    }

    public void UpdateStats(int newStrength, int newShield, int newAgility, int newSpeed)
{
    
    shield = newShield;
   
    agility = newAgility;
   
    strength = newStrength;
   
    speed = newSpeed;
    

}
public void RemoveItem(string statName)
{
    EquipmentPanel equipmentPanel = GetComponent<Character>().equipmentPanel;
    // if (equipmentPanel == null)
    // {
    //     equipmentPanel = character.GetEquipmentPanel();
    // }

    Debug.Log("Trying to remove item affecting " + statName);

    EquippableItem itemToRemove = null;
    int highestBonus = 0;

    // Iterate through all equipped items
    foreach (EquippableItem item in equipmentPanel.EquippedItems)
    {
        // Find the item that affects the specified stat and has the highest bonus
        int bonus = 0;
        switch (statName)
        {
            case "Strength":
                bonus = item.StrengthBonus;
                break;
            case "Shield":
                bonus = item.ShieldBonus;
                break;
            case "Agility":
                bonus = item.AgilityBonus;
                break;
            case "Speed":
                bonus = item.SpeedBonus;
                break;
        }
        
        if (bonus > highestBonus)
        {
            highestBonus = bonus;
            itemToRemove = item;
        }
    }

    if (itemToRemove != null)
    {
        Debug.Log("Removing item: " + itemToRemove.name);
        equipmentPanel.RemoveItem(itemToRemove);
    }
}


   
}