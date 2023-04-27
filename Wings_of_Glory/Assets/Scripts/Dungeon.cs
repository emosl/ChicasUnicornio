// This script implements the dungeon, the loading of the dungeon scene, 
//the respawn of the player, and the question to enter the dungeon.

// Chicas Unicornio: Dungeon in Wings of Glory

// Firstly, we implement the libraries needed for the script.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// We create the class Dungeon and we inherit from MonoBehaviour.
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

    //this method finds the player game object and sets the 
    //lastPlayerPos variable to the player's initial position
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPlayerPos = player.transform.position; // save player's initial position
        obstacleCollider = GetComponent<Collider2D>(); 
        preguntas = canvas.GetComponent<Preguntas>(); 

    }

    // this method checks if the  player has collided with the dungeon entrance 
    public void Scene()
    {
        lastPlayerPos = player.transform.position; // save player's last position before loading scene
        SceneManager.LoadScene(sceneName); 
    }

    // this method respawns the player at the dungeon entrance
    public void RespawnD()
    {
        player.transform.position = respawn.position;
    }

    // this method returns the player to the last saved position
    public void ReturnToLastPos()
    {
        player.transform.position = lastPlayerPos; // set player's position to last saved position
    }

    // this method asks the playerif they want to enter the dungeon
    public void AskPermissionD()
    {
        preguntas.ShowQuestionD("Do you want to go into Dungeon?", OnTriggerDecision);
        Debug.Log("AskPermissionD");
        UndoTriggersForObstacleColliders();
        
    }

    //this method checks the players answer to the question and acts accordingly
    private void OnTriggerDecision(bool shouldTrigger)
    {
        if (shouldTrigger)
        {
            //yes, shows the scene
            Scene();
            // MakeTriggersForObstacleColliders();
            //ReturnToLastPos();
            
        }
        else
        {
            //no, returns to last position
            TurnTriggerIntoCollider();
              
        }
        
        // Debug.Log("Should trigger: " + shouldTrigger);
    }

    //this method deactivates the trigger and hides the option of the question
     public void TurnTriggerIntoCollider()
    {
        obstacleCollider.isTrigger = false;
        canvas.GetComponent<Preguntas>().HideQuestion();
    }

    //creates the trigger for the obstacle colliders
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

    // this method deactivates the trigger for the obstacle colliders
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