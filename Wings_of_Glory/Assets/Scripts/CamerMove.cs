// using UnityEngine;
// using System.Collections;

// public class CamerMove : MonoBehaviour {

//     // public Transform target;
//     // public float smoothSpeed = 0.125f;
//     // public Vector3 offset;

//     // void LateUpdate() {
//     //     // Set the camera's position to the player's position plus an offset
//     //     Vector3 desiredPosition = target.position + offset;
//     //     Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//     //     transform.position = smoothedPosition;
//     // }
//     public GameObject player;
//     private Vector3 offset;

//     private void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player");
//         offset = transform.position - player.transform.position;
//     }

//     private void LateUpdate()
//     {
//         if (player != null)
//         {
//             transform.position = player.transform.position + offset;
//         }
//     }
// }

using UnityEngine;
using System.Collections;

public class CamerMove : MonoBehaviour {

    public GameObject player;      
    private Vector3 offset;            


    void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate () 
    {
        transform.position = player.transform.position + offset;
    }
}