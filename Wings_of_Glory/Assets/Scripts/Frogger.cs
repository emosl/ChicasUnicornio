using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;


public class Frogger : MonoBehaviour
{
   
    private SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite leapSprite;
    public Sprite deathSprite;
    private Vector3 spawnPosition;
    private float farthestRow; 

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

    private void Move(Vector3 direction)
    {
        Vector3 destination = transform.position + direction; 
        // Collider2D barrier = Physics2D.Overlapbox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D barrier = Physics2D.OverlapArea(destination - Vector3.one * 0.5f, destination + Vector3.one * 0.5f, LayerMask.GetMask("Barrier"));
        Collider2D platform = Physics2D.OverlapArea(destination - Vector3.one * 0f, destination + Vector3.one * 0f, LayerMask.GetMask("Platform"));
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

    public void Death()
    {
       StopAllCoroutines();
       transform.rotation = Quaternion.identity;
       spriteRenderer.sprite = deathSprite;
       enabled = false;

       FindObjectOfType<GameManager>().Died();
    }

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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(enabled && other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && transform.parent == null){
            Death();
        }
    }

}
