// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Obstacle : MonoBehaviour
// {
//     private Collider2D obstacleCollider;
//     public GameObject canvas;
//     private Preguntas preguntas;

//     // Start is called before the first frame update
//     void Start()
//     {
//         obstacleCollider = GetComponent<Collider2D>();
//         preguntas = canvas.GetComponent<Preguntas>();
//         preguntas.NoButtonPressed += TurnTriggerIntoCollider;
//     }

//     public void AskPermission()
//     {
//         Restart();
//         preguntas.GetComponent<Preguntas>().Start();
//         preguntas.ShowQuestion("Do you want to go through this obstacle?");
//     }

//     public void MakeTrigger()
//     {
//         obstacleCollider.isTrigger = true;
//         canvas.GetComponent<Preguntas>().HideQuestion();
        
        
//     }

//     private void TurnTriggerIntoCollider()
//     {
//         obstacleCollider.isTrigger = false;
//         canvas.GetComponent<Preguntas>().HideQuestion();
        
//     }

//     void OnDestroy()
//     {
//         // Unsubscribe the event when the object is destroyed
//         if (preguntas != null)
//         {
//             preguntas.NoButtonPressed -= TurnTriggerIntoCollider;
//         }
//     }
//     public void Restart()
//     {
//         obstacleCollider.isTrigger = true;
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Collider2D obstacleCollider;
    private bool isTrigger = true;
    public GameObject canvas;
    private Preguntas preguntas;

    // Start is called before the first frame update
    void Start()
    {
        obstacleCollider = GetComponent<Collider2D>();
        preguntas = canvas.GetComponent<Preguntas>();
        preguntas.NoButtonPressed += OnNoButtonPressed;
    }

    public void AskPermission()
    {
        if (isTrigger)
        {
            Restart();
            preguntas.Start();
            preguntas.ShowQuestion("Do you want to go through this obstacle?");
        }
        else
        {
            obstacleCollider.isTrigger = true;
        }
    }

    public void MakeTrigger()
    {
        obstacleCollider.isTrigger = true;
        isTrigger = true;
        canvas.GetComponent<Preguntas>().HideQuestion();
    }

    private void OnNoButtonPressed()
    {
        if (isTrigger)
        {
            obstacleCollider.isTrigger = false;
            isTrigger = false;
            canvas.GetComponent<Preguntas>().HideQuestion();
        }
    }

    void OnDestroy()
    {
        // Unsubscribe the event when the object is destroyed
        if (preguntas != null)
        {
            preguntas.NoButtonPressed -= OnNoButtonPressed;
        }
    }

    public void Restart()
    {
        obstacleCollider.isTrigger = true;
        isTrigger = true;
    }
}
