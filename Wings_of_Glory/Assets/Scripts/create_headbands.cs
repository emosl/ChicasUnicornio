using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_headbands : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject[] gadgetsheadbands;
    
    public void Start()
    {
        creategadgets();
    }

    public void creategadgets()
    {
        int rand = Random.Range(0, gadgetsheadbands.Length);
        Instantiate(gadgetsheadbands[rand], transform.position, Quaternion.identity);
        
    }
    void Update(){
        if (gadgetsheadbands == null)
        {
            creategadgets();
        }
    }
}
