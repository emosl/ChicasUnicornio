using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_metals : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject[] gadgetsmetal;
    
    public void Start()
    {
        creategadgets();
    }

    public void creategadgets()
    {
        int rand = Random.Range(0, gadgetsmetal.Length);
        Instantiate(gadgetsmetal[rand], transform.position, Quaternion.identity);
        
    }
}
