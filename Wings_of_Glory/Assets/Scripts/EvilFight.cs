using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilFight : MonoBehaviour
{
    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public GameObject player;  
    public Transform objectToFollow;

    public float groundCheckRadius = 1f;
    public LayerMask groundLayerMask;

    private bool isGrounded;
    private bool isMoving;
    public float speed = 20f;


    public Sprite idleSprite;
    public Sprite leapSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, speed * Time.deltaTime);
    }
}
