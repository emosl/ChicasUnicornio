using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuStream : MonoBehaviour
{
    public Button PlayButton;
    public string sceneName;
    
    
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
        
        ButtonPressed?.Invoke(decision);
        Debug.Log("Play");
        // SceneManager.LoadScene(sceneName);
        StartCoroutine(WaitAndDoSomething());
        
    
    }

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(sceneName);
    }   

   
}
