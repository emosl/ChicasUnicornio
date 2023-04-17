// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Preguntas: MonoBehaviour
// {
//     public GameObject canvas;
//     // Start is called before the first frame update
//     void Start()
//     {
//         canvas.SetActive(false);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (canvas.activeSelf)
//         {
//             if (Input.GetKeyDown(KeyCode.Return))
//             {
//                 // The user clicked "Yes"
//                 Debug.Log("Game continued!"); // continue playing

//             }
//             else if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 // The user clicked "No"
//                 Debug.Log("Game stopped!"); // stop playing
//                 Application.Quit(); // quit the application
//             }
//         }
            
//     }
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.gameObject.CompareTag("Player"))
//         {
//             canvas.SetActive(true);
//         }
//     }
//     // public void ShowQuestion(string question)
//     // {
//     //     canvas.SetActive(true);
//     //     Text questionText = canvas.GetComponentInChildren<Text>();
//     //     questionText.text = question;
//     // }
//     public void ButtonPressed()
//     {
//         canvas.SetActive(false);
//     }
//     // void HideQuestion()
//     // {
//     //     canvas.SetActive(false);
//     // }
    
// }
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Preguntas : MonoBehaviour
// {
//     public GameObject canvas;
//     private bool userAnswer;

//     // Start is called before the first frame update
//     void Start()
//     {
//         canvas.SetActive(false);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (canvas.activeSelf)
//         {
//             if (Input.GetKeyDown(KeyCode.Return))
//             {
//                 // The user clicked "Yes"
//                 Debug.Log("Game continued!"); // continue playing
//                 userAnswer = true;
//                 canvas.SetActive(false);
//             }
//             else if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 // The user clicked "No"
//                 Debug.Log("Game stopped!"); // stop playing
//                 userAnswer = false;
//                 canvas.SetActive(false);
//                 Application.Quit(); // quit the application
//             }
//         }        
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.gameObject.CompareTag("Player"))
//         {
//             canvas.SetActive(true);
//         }
//     }

//     public void ShowQuestion(string question)
//     {
//         canvas.SetActive(true);
//         Text questionText = canvas.GetComponentInChildren<Text>();
//         questionText.text = question;
//     }

//     public bool GetUserAnswer()
//     {
//         return userAnswer;
//     }

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preguntas : MonoBehaviour
{
    public GameObject canvas;
    public Button yesButton;
    public Button noButton;
    private Toby toby;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        toby = FindObjectOfType<Toby>();

        yesButton.onClick.AddListener(() => {
            canvas.SetActive(false);
            toby.PermissionGranted();
        });

        noButton.onClick.AddListener(() => {
            canvas.SetActive(false);
        });
    }

    public void ShowQuestion(string question)
    {
        canvas.SetActive(true);
        Text questionText = canvas.GetComponentInChildren<Text>();
        questionText.text = question;
    }
}