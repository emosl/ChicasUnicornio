using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{
    public static string usernameID; // The global variable to store the username ID
    
    [SerializeField] private InputField usernameIDInputField; // The input field for the username ID
    
    public void OnPlayButtonClicked()
    {
        usernameID = usernameIDInputField.text; // Assign the username ID from the input field to the global variable
    }
}

