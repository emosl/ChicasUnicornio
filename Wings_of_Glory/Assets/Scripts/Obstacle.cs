using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Collider2D obstacleCollider;
    public GameObject canvas;
    private Preguntas preguntas;
    public Animator bombs;
    public Animator wave;
    public Animator ice;
    public Animator rock;

    // Start is called before the first frame update
    void Start()
    {
        obstacleCollider = GetComponent<Collider2D>();
        preguntas = canvas.GetComponent<Preguntas>();
        preguntas.ButtonPressed += OnTriggerDecision;
        bombs.Play("bomb_idle");
        wave.Play("wave_idle");
        ice.Play("ice_idle");
        rock.Play("rock_idle");
        
    }

    public void AskPermission()
    {
        preguntas.ShowQuestion("Do you want to go through this obstacle?", OnTriggerDecision);
        Debug.Log("AskPermission");
        UndoTriggersForObstacleColliders();
        bombs.Play("bomb_idle");
        wave.Play("wave_idle");
        ice.Play("ice_idle");
        rock.Play("rock_idle");
    }

    private void OnTriggerDecision(bool shouldTrigger)
    {
        if (shouldTrigger)
        {
            //yes
            MakeTriggersForObstacleColliders();
            bombs.Play("bomb_anim");
            wave.Play("wave_anim");
            ice.Play("ice_anim");
            rock.Play("rock_anim");
            
        }
        else
        {
            //no
            TurnTriggerIntoCollider();
            Restart();
        }
        
        Debug.Log("Should trigger: " + shouldTrigger);
    }

    public void MakeTriggersForObstacleColliders()
    {
        GameObject[] obstacleColliders = GameObject.FindGameObjectsWithTag("Obstacle_Collider");
        foreach (GameObject obstacleColliderObject in obstacleColliders)
        {
            Collider2D collider = obstacleColliderObject.GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.isTrigger = true;
            }
        }
        canvas.GetComponent<Preguntas>().HideQuestion();
    }
    public void UndoTriggersForObstacleColliders()
    {
        GameObject[] obstacleColliders = GameObject.FindGameObjectsWithTag("Obstacle_Collider");
        foreach (GameObject obstacleColliderObject in obstacleColliders)
        {
            Collider2D collider = obstacleColliderObject.GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.isTrigger = false;
            }
        }
        // canvas.GetComponent<Preguntas>().HideQuestion();
    }


    public void TurnTriggerIntoCollider()
    {
        obstacleCollider.isTrigger = false;
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
    }
}