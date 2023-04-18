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
        Restart();
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
        canvas.GetComponent<Preguntas>().HideQuestion();
        
    }

    void OnDestroy()
    {
        // Unsubscribe the event when the object is destroyed
        if (preguntas != null)
        {
            preguntas.NoButtonPressed -= TurnTriggerIntoCollider;
        }
    }
    public void Restart()
    {
        obstacleCollider.isTrigger = true;
    }
}
