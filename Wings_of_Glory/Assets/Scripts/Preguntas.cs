using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preguntas : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    public GameObject canvas;

    public event Action<bool> ButtonPressed;
    

    private void Start()
    {
        canvas.SetActive(false);

        yesButton.onClick.AddListener(delegate { OnButtonPress(true); });
        noButton.onClick.AddListener(delegate { OnButtonPress(false); });
    }

    public void ShowQuestion(string question, Action<bool> callback)
    {
        canvas.SetActive(true);
         Text questionText = canvas.GetComponentInChildren<Text>();
        ButtonPressed = callback;
    }

    public void ShowQuestionD(string question, Action<bool> callback)
    {
        canvas.SetActive(true);
         Text questionText = canvas.GetComponentInChildren<Text>();
        ButtonPressed = callback;
    }


    public void HideQuestion()
    {
        canvas.SetActive(false);
    }

    private void OnButtonPress(bool decision)
    {
        ButtonPressed?.Invoke(decision);
        HideQuestion();
    }

    

    void OnDestroy()
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
    }
}

