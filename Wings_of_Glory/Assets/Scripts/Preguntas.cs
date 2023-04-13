using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preguntas : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // The user clicked "Yes"
                Debug.Log("Game continued!"); // continue playing

            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                // The user clicked "No"
                Debug.Log("Game stopped!"); // stop playing
                Application.Quit(); // quit the application
            }
        }
            
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
    }
    // void ShowQuestion(string question)
    // {
    //     canvas.SetActive(true);
    //     Text questionText = canvas.GetComponentInChildren<Text>();
    //     questionText.text = question;
    // }

    // void HideQuestion()
    // {
    //     canvas.SetActive(false);
    // }
    
}
