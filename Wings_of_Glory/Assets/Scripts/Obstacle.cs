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
//         preguntas.ButtonPressed += OnTriggerDecision;
        
//     }

//     public void AskPermission()
//     {
//         preguntas.ShowQuestion("Do you want to go through this obstacle?", OnTriggerDecision);
//     }

//     private void OnTriggerDecision(bool shouldTrigger)
//     {
//         if (shouldTrigger)
//         {
//             MakeTriggersForObstacleColliders();
//         }
//         else
//         {
//             TurnTriggerIntoCollider();
//         }
//     }

//     public void MakeTriggersForObstacleColliders()
//     {
//         GameObject[] obstacleColliders = GameObject.FindGameObjectsWithTag("Obstacle_Collider");
//         foreach (GameObject obstacleColliderObject in obstacleColliders)
//         {
//             Collider2D collider = obstacleColliderObject.GetComponent<Collider2D>();
//             if (collider != null)
//             {
//                 collider.isTrigger = true;
//             }
//         }
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
//             preguntas.ButtonPressed -= OnTriggerDecision;
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
    public GameObject canvas;
    private Preguntas preguntas;

    // Start is called before the first frame update
    void Start()
    {
        obstacleCollider = GetComponent<Collider2D>();
        preguntas = canvas.GetComponent<Preguntas>();
        preguntas.ButtonPressed += OnTriggerDecision;
    }

    public void AskPermission()
    {
        preguntas.ShowQuestion("Do you want to go through this obstacle?", OnTriggerDecision);
    }

    private void OnTriggerDecision(bool shouldTrigger)
    {
        if (shouldTrigger)
        {
            MakeTriggerForCurrentCollider();
        }
        else
        {
            TurnTriggerIntoCollider();
        }
    }

    private void MakeTriggerForCurrentCollider()
    {
        // Set the current collider as trigger
        obstacleCollider.isTrigger = true;

        // Set the other colliders as non-trigger
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            if (collider != obstacleCollider && collider.CompareTag("Obstacle_Collider"))
            {
                collider.isTrigger = false;
            }
        }

        canvas.GetComponent<Preguntas>().HideQuestion();
    }

    private void TurnTriggerIntoCollider()
    {
        // Set the current collider as non-trigger
        obstacleCollider.isTrigger = false;

        // Set the other colliders as non-trigger
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            if (collider != obstacleCollider && collider.CompareTag("Obstacle_Collider"))
            {
                collider.isTrigger = false;
            }
        }

        canvas.GetComponent<Preguntas>().HideQuestion();
    }

    void OnDestroy()
    {
        // Unsubscribe the event when the object is destroyed
        if (preguntas != null)
        {
            preguntas.ButtonPressed -= OnTriggerDecision;
        }
    }

    public void Restart()
    {
        obstacleCollider.isTrigger = true;

        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            if (collider != obstacleCollider && collider.CompareTag("Obstacle_Collider"))
            {
                collider.isTrigger = false;
            }
        }
    }
}
