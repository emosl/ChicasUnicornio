//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 3, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string input;
    public static string username_ID; // The global variable to store the username ID
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ReadStringInput(string s)
   {
       input = s; // Assign the passed string argument to a variable called "input"
       username_ID = input; // Assign the value of "input" to a variable named "username_ID"
       // Debug.Log(username_ID); // Print the value of "username_ID" in the Console (commented out for now)
   }
   
}
