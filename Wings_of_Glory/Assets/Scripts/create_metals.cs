//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
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
