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

    public event Action<bool> ButtonPressed; 
    // Start is called before the first frame update
    void Start()
    {
        PinkButton.onClick.AddListener(delegate { OnButtonPress(true); });
        BlueButton.onClick.AddListener(delegate { OnButtonPress(true); });
        RedButton.onClick.AddListener(delegate { OnButtonPress(true); });   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnButtonPress(bool decision)
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