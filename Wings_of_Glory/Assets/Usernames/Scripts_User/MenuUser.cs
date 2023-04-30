using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Video;
using TMPro;

public class MenuUser : MonoBehaviour
{
    public Button PlayButton;
    public Button UpdateBotton;
    public string sceneName;
    public AudioSource Audio;
    public static string UiD; // The global variable to store the username ID
    private string input;

    [SerializeField] APITest api;
    [SerializeField] public TMP_InputField usernameIDInputField;

    public event Action<bool> ButtonPressed; 
    // Start is called before the first frame update
    void Start()
    {
        // canvas.SetActive(false);
        PlayButton.onClick.AddListener(delegate { OnButtonPress(true); });
        UpdateBotton.onClick.AddListener(delegate { OnButtonPress2(true); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnButtonPress(bool decision)
    {
        
        ButtonPressed?.Invoke(decision);
        Audio.Play();
        OnPlayButtonClicked();
        // Debug.Log(UiD);
        GetUser();
        StartCoroutine(WaitAndDoSomething());
        
    
    }
    private void OnButtonPress2(bool decision)
    {
        
        ButtonPressed?.Invoke(decision);
        Audio.Play();
        UpdateData();
        
    
    }

    

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(5.3f);
        SceneManager.LoadScene(sceneName);
    }   

    
    
     // The input field for the username ID
    
    public void OnPlayButtonClicked()
    {
        UiD = usernameIDInputField.text; // Assign the username ID from the input field to the global variable
    }

    public void GetUser()
    {
        api.QueryUser(UiD);
    }
    public void UpdateData()
    {
        api.UpdateData();
    }
   
}
