using UnityEngine;
using System.Collections;

public class CamerMove : MonoBehaviour {

    public GameObject player;      
    private Vector3 offset;
    public Transform target;
    public Transform previousTarget;
    public float smoothSpeed = 0.125f;            


    public void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + offset;
    }

    // void LateUpdate()
    // {
    //     if (target == null)
    // {
    //     // If the target is not set, find the player with the "Player" tag and set it as the target
    //     GameObject player = GameObject.FindGameObjectWithTag("Player");
    //     if (player != null)
    //     {
    //         target = player.transform;
    //     }
    //     else
    //     {
    //         target = previousTarget; // If no player is found, set the target to the previous target position
    //     }
    // }

    // if (target != null)
    // {
    //     Vector3 desiredPosition = target.position + offset;
    //     Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //     transform.position = smoothedPosition;
    // }
    // }

    public void TrackToby()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + offset;
    }
   
}