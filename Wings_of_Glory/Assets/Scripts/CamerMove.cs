

using UnityEngine;
using System.Collections;

public class CamerMove : MonoBehaviour {

    public GameObject player;      
    private Vector3 offset;            


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
   
}