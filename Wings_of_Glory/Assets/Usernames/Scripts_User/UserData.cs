//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 3, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UserData : MonoBehaviour
{
    public static string usernameID; // The global variable to store the username ID
    
    [SerializeField] public TMP_InputField usernameIDInputField; // The input field for the username ID
    
    public void OnPlayButtonClicked()
    {
        usernameID = usernameIDInputField.text; // Assign the username ID from the input field to the global variable
    }
}
