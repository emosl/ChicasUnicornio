using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_food : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject[] gadgetsfood;
    
    public void Start()
    {
        creategadgets();
    }

    public void creategadgets()
    {
        int rand = Random.Range(0, gadgetsfood.Length);
        Instantiate(gadgetsfood[rand], transform.position, Quaternion.identity);
        
    }
}
