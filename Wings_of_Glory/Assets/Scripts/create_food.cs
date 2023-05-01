//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_food : MonoBehaviour
{
    // Start is called before the first frame update
   //This list contains the food gadgets that will be picked randomly.
    public GameObject[] gadgetsfood;
    
    
    public void Start()
    {
        creategadgets();
    }

    // void Update(){

    // }

    public void creategadgets()
    {
        int rand = Random.Range(0, gadgetsfood.Length);
        Instantiate(gadgetsfood[rand], transform.position, Quaternion.identity);
        
    }
}
