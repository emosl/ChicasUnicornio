using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_horseshoe : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject[] gadgetshorseshoe;
    
    public void Start()
    {
        creategadgets();
    }

    public void creategadgets()
    {
        int rand = Random.Range(0, gadgetshorseshoe.Length);
        Instantiate(gadgetshorseshoe[rand], transform.position, Quaternion.identity);
        
    }
}
