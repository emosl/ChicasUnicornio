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
using UnityEngine.Audio;

public class MenuStream : MonoBehaviour
{
    public Button PlayButton;
    public string sceneName;
    public AudioSource Audio;

    
    
    // public GameObject canvas;

    public event Action<bool> ButtonPressed; 
    // Start is called before the first frame update
    void Start()
    {
        // canvas.SetActive(false);
        PlayButton.onClick.AddListener(delegate { OnButtonPress(true); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnButtonPress(bool decision)
  {
      ButtonPressed?.Invoke(decision); // Invoke an event called "ButtonPressed" passing the "decision" boolean parameter
      Debug.Log("Play"); // Print "Play" to the Console
      Audio.Play(); //Play the audio source
      // SceneManager.LoadScene(sceneName); // Load a scene (commented out for now)
      StartCoroutine(WaitAndDoSomething()); // Start a coroutine called "WaitAndDoSomething"
  }
  
  IEnumerator WaitAndDoSomething()
  {
      yield return new WaitForSeconds(2.3f); // Wait for 2.3 seconds
      SceneManager.LoadScene(sceneName); // Load a scene called "sceneName" after the wait time
  }
   

   
}
