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

    public GameManagerFight muleFight;
    // Start is called before the first frame update
    public void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        animator.Play("mula_caminando");
        
    }

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 offset = new Vector2(0f, -bounds.extents.y);
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + offset, groundCheckRadius, groundLayerMask);
        // transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, speed * Time.deltaTime);
    }
    public void PushMule()
    {
       transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, muleFight.mule_speed * Time.deltaTime);
       transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        animator.Play("mula_atack");
    }
    
}
