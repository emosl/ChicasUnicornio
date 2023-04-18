// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class Obstacle : MonoBehaviour
// // {
// //     private Collider2D obstacleCollider;

// //     // Start is called before the first frame update
// //     void Start()
// //     {
// //         obstacleCollider = GetComponent<Collider2D>();
// //     }

// //     public void OnTriggerEnter2D(Collider2D other)
// //     {
// //         if (other.gameObject.CompareTag("Player"))
// //         {
// //             Preguntas preguntas = FindObjectOfType<Preguntas>();
// //             preguntas.ShowQuestion("Do you want to go through this obstacle?");
// //             bool userAnswer = preguntas.GetUserAnswer();
// //             if (userAnswer)
// //             {
// //                 obstacleCollider.isTrigger = true;
// //             }
// //         }
// //     }
// // }
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Obstacle : MonoBehaviour
// {
//     private Collider2D obstacleCollider;
//     public GameObject canvas;

//     // Start is called before the first frame update
//     void Start()
//     {
//         obstacleCollider = GetComponent<Collider2D>();
//     }

//     public void AskPermission()
//     {
//         canvas.GetComponent<Preguntas>().Start();
//         canvas.GetComponent<Preguntas>().ShowQuestion("Do you want to go through this obstacle?");
    
//     }

//     public void MakeTrigger()
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
    public GameObject canvas;
    private Preguntas preguntas;

    // Start is called before the first frame update
    void Start()
    {
        obstacleCollider = GetComponent<Collider2D>();
        preguntas = canvas.GetComponent<Preguntas>();
        preguntas.NoButtonPressed += TurnTriggerIntoCollider;
    }

    public void AskPermission()
    {
        preguntas.GetComponent<Preguntas>().Start();
        preguntas.ShowQuestion("Do you want to go through this obstacle?");
    }

    public void MakeTrigger()
    {
        obstacleCollider.isTrigger = true;
        canvas.GetComponent<Preguntas>().HideQuestion();
    }

    private void TurnTriggerIntoCollider()
    {
        obstacleCollider.isTrigger = false;
    }

    void OnDestroy()
    {
        // Unsubscribe the event when the object is destroyed
        if (preguntas != null)
        {
            preguntas.NoButtonPressed -= TurnTriggerIntoCollider;
        }
    }
}
