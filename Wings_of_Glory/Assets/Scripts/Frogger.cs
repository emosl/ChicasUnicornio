//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
// This script controls the movement and actions of a character 
//in a 2D game and handles collisions with different objects in 
//the game world. 
// Frogger-like game.

// Chicas Unicornio: Dungeon in Wings of Glory

// Firstly, we implement the libraries needed for the script.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;

// We create the class Frogger and we inherit from MonoBehaviour.
public class Frogger : MonoBehaviour
{
   // we define as public variables several sprite objects
   // that correspond to the frogger's state.
   // we define the sprite renderer component and the spawn position
    private SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite leapSprite;
    public Sprite deathSprite;
    private Vector3 spawnPosition;
    private float farthestRow; 

    // We define the Awake function, which is called when the script instance is being loaded.
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPosition = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
       // We define the movement of the frogger using the arrow keys, 
       // this function checks the input added by the player and moves the frogger accordingly.
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Move(Vector3.up);
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            Move(Vector3.down);
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
           transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Move(Vector3.left);
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            Move(Vector3.right);
        }
    }

    // We define the Move function, which moves the frogger in the direction 
    //specified by the parameter and checks for collisions.
    private void Move(Vector3 direction)
    {
        Vector3 destination = transform.position + direction; 
        // Collider2D barrier = Physics2D.Overlapbox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        
        // if there is a barrier, the frogger does not move.
        Collider2D barrier = Physics2D.OverlapArea(destination - Vector3.one * 0.5f, destination + Vector3.one * 0.5f, LayerMask.GetMask("Barrier"));
        
        // if there is a platform, the frogger moves with the platform.
        Collider2D platform = Physics2D.OverlapArea(destination - Vector3.one * 0f, destination + Vector3.one * 0f, LayerMask.GetMask("Platform"));
        
        // if there is an obstacle, the frogger dies.
        Collider2D obstacle = Physics2D.OverlapArea(destination - Vector3.one * 0f, destination + Vector3.one * 0f, LayerMask.GetMask("Obstacle"));
        if(barrier != null){
             return;
           }
        if(platform != null){
            transform.SetParent(platform.transform);
        } else{
            transform.SetParent(null);
        }

        if(obstacle != null && platform == null){
            transform.position=destination; 
            Death();
        }else
        {
            if(destination.y > farthestRow){
                farthestRow = destination.y;
            }
            FindObjectOfType<GameManager>().AdvancedRow();
            StartCoroutine(Leap(destination));
        }

    }

    // this method implements the froggers movement.
    private IEnumerator Leap(Vector3 destination)
    {
        Vector3 startPosition = transform.position;
        spriteRenderer.sprite = leapSprite;

        float elapsed = 0f;
        float duration = 0.125f; 
        while (elapsed < duration){
            transform.position = Vector3.Lerp(startPosition, destination, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = destination;
        spriteRenderer.sprite = idleSprite;
    }

    // this method implements the froggers death.
    public void Death()
    {
        //it stops all the coroutines, 
        //sets the rotation to the identity quaternion, 
        //and sets the character at spawn position. 

       StopAllCoroutines();
       transform.rotation = Quaternion.identity;
       spriteRenderer.sprite = deathSprite;
       enabled = false;

       FindObjectOfType<GameManager>().Died();
    }

    // this method is called when the frogger reaches the end of the level. 
    public void Respwan()
    {
        StopAllCoroutines();
        transform.rotation = Quaternion.identity;
        transform.position = spawnPosition;
        farthestRow = spawnPosition.y;
        spriteRenderer.sprite = idleSprite;
        gameObject.SetActive(true);
        enabled = true;
    }

    // this method is called when the frogger collides with an obstacle.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(enabled && other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && transform.parent == null){
            Death();
        }
    }

}
