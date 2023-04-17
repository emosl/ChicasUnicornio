// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Obstacle : MonoBehaviour
// {
//     private Collider2D obstacleCollider;

//     // Start is called before the first frame update
//     void Start()
//     {
//         obstacleCollider = GetComponent<Collider2D>();
//     }

//     public void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.gameObject.CompareTag("Player"))
//         {
//             Preguntas preguntas = FindObjectOfType<Preguntas>();
//             preguntas.ShowQuestion("Do you want to go through this obstacle?");
//             bool userAnswer = preguntas.GetUserAnswer();
//             if (userAnswer)
//             {
//                 obstacleCollider.isTrigger = true;
//             }
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Collider2D obstacleCollider;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        obstacleCollider = GetComponent<Collider2D>();
    }

    public void AskPermission()
    {
        canvas.GetComponent<Preguntas>().Start();
        canvas.GetComponent<Preguntas>().ShowQuestion("Do you want to go through this obstacle?");
    
    }

    public void MakeTrigger()
    {
        obstacleCollider.isTrigger = true;
    }
}