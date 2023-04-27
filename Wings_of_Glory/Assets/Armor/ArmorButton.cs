using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Video;

public class ArmorButton : MonoBehaviour
{
    public Button PinkButton;
    public Button BlueButton;
    public Button RedButton;
    public string sceneName;
    public AudioSource Audio;
    string username = MenuUser.UiD;

    public event Action<bool> ButtonPressed; 
    // Start is called before the first frame update
    void Start()
    {
        PinkButton.onClick.AddListener(delegate { OnButtonPressPink(true); });
        BlueButton.onClick.AddListener(delegate { OnButtonPressBlue(true); });
        RedButton.onClick.AddListener(delegate { OnButtonPressRed(true); });   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(username);
    }
    private void OnButtonPressPink(bool decision)
    {
        
        ButtonPressed?.Invoke(decision);
        Audio.Play();
        Debug.Log("Play");
        // SceneManager.LoadScene(sceneName);
        StartCoroutine(WaitAndDoSomething());
        
    
    }
    private void OnButtonPressBlue(bool decision)
    {
        
        ButtonPressed?.Invoke(decision);
        Audio.Play();
        Debug.Log("Play");
        // SceneManager.LoadScene(sceneName);
        StartCoroutine(WaitAndDoSomething());
        
    
    }
    private void OnButtonPressRed(bool decision)
    {
        
        ButtonPressed?.Invoke(decision);
        Audio.Play();
        Debug.Log("Play");
        // SceneManager.LoadScene(sceneName);
        StartCoroutine(WaitAndDoSomething());
        
    }

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }   

}
