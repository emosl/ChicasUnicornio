using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Dungeon : MonoBehaviour

{
    public Transform target;
    public Transform respawn;
    public string sceneName;
    public string sceneToLoad;
    public GameObject player;
    private Vector3 lastPlayerPos; // variable to store player's last position

    private Collider2D obstacleCollider;
    public GameObject canvas;
    private Preguntas preguntas;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPlayerPos = player.transform.position; // save player's initial position
        obstacleCollider = GetComponent<Collider2D>();
        preguntas = canvas.GetComponent<Preguntas>();

    }


    public void Scene()
    {
        lastPlayerPos = player.transform.position; // save player's last position before loading scene
        SceneManager.LoadScene(sceneName);
    }

    public void RespawnD()
    {
        player.transform.position = respawn.position;
    }

    public void ReturnToLastPos()
    {
        player.transform.position = lastPlayerPos; // set player's position to last saved position
    }

    public void AskPermissionD()
    {
        preguntas.ShowQuestionD("Do you want to go into Dungeon?", OnTriggerDecision);
        Debug.Log("AskPermissionD");
        UndoTriggersForObstacleColliders();
        
    }

    private void OnTriggerDecision(bool shouldTrigger)
    {
        if (shouldTrigger)
        {
            //yes
            Scene();
            // MakeTriggersForObstacleColliders();
            //ReturnToLastPos();
            
        }
        else
        {
            //no
            TurnTriggerIntoCollider();
            
            
        }
        
        Debug.Log("Should trigger: " + shouldTrigger);
    }

     public void TurnTriggerIntoCollider()
    {
        obstacleCollider.isTrigger = false;
        canvas.GetComponent<Preguntas>().HideQuestion();
    }

    public void MakeTriggersForObstacleColliders()
    {
        GameObject[] obstacleColliders = GameObject.FindGameObjectsWithTag("Obstacle_Dungeon");
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
        GameObject[] obstacleColliders = GameObject.FindGameObjectsWithTag("Obstacle_Dungeon");
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
     void OnDestroy()
    {
        // Unsubscribe the event when the object is destroyed
        if (preguntas != null)
        {
            preguntas.ButtonPressed -= OnTriggerDecision;
        }
    }


}
