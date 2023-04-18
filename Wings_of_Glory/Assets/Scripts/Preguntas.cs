using System;
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
    private Obstacle obstacleCollider;
    public event Action NoButtonPressed;

    // Start is called before the first frame update
    public void Start()
    {
        canvas.SetActive(false);
        toby = FindObjectOfType<Toby>();

        yesButton.onClick.AddListener(() => {
            canvas.SetActive(false);
            toby.PermissionGranted();
            canvas.SetActive(false);
        });

        noButton.onClick.AddListener(() => {
            canvas.SetActive(false);
            // toby.PermissionDenied();
            NoButtonPressed?.Invoke();
        });

        

    }

    public void ShowQuestion(string question)
    {
        canvas.SetActive(true);
        Text questionText = canvas.GetComponentInChildren<Text>();
        // questionText.text = question;
    }

    public void HideQuestion()
    {
        canvas.SetActive(false);
        Debug.Log("HideQuestion");

    }
}
