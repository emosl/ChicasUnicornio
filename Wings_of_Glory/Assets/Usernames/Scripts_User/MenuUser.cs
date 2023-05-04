//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 3, 2023
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using TMPro;

public class MenuUser : MonoBehaviour
{
    // Declaring public variables for Unity objects
    public Button PlayButton;
    public Button UpdateBotton;
    public string sceneName;
    public static string UiD; // The global variable to store the username ID
    private string input;

    [SerializeField] APITest api; // SerializeField attribute allows private fields to be shown in the Inspector
    [SerializeField] public TMP_InputField usernameIDInputField; // Input field displayed in the UI

    public event Action<bool> ButtonPressed; // Event named "ButtonPressed" with a parameter of bool type

    // Start is called before the first frame update
    void Start()
    {
        // Assigning methods to button click events
        PlayButton.onClick.AddListener(delegate { OnButtonPress(true); });
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method invoked when PlayButton is clicked
    private void OnButtonPress(bool decision)
    {
        ButtonPressed?.Invoke(decision); // Invoking the ButtonPressed event
        OnPlayButtonClicked(); // Calling method to assign username ID from the input field to global variable
        GetUser(); // Calling method to query user data from API
        StartCoroutine(WaitAndDoSomething()); // Calling coroutine to wait for 5.3 seconds and then load next scene
    
    }
  
    // Coroutine to wait for 5.3 seconds and then load next scene, 5.3 for sound to finish playing
    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(5.3f);
        SceneManager.LoadScene(sceneName); // Loading the next scene
    }   

     // Method to assign username ID from input field to global variable
    public void OnPlayButtonClicked()
    {
        UiD = usernameIDInputField.text; // Assigning the username ID from the input field to the global variable
    }

    // Method to query user data from API using the username ID
    public void GetUser()
    {
        api.QueryUser(UiD);
    }

    // Method to update user data using API
    public void UpdateData()
    {
        api.UpdateData();
    }
   
}
