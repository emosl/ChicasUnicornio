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
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        animator.Play("mula_idle");
    }

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 offset = new Vector2(0f, -bounds.extents.y);
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + offset, groundCheckRadius, groundLayerMask);
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, speed * Time.deltaTime);
    }
    
}
