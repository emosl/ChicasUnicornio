// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class SceneManager : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     public Transform targetPosition; // The position the player needs to reach to load the new scene
//     public string sceneToLoad; // The name of the scene to load

//     private bool isSceneLoaded = false;

//     void Update()
//     {
//         // Check if the player has reached the target position
//         if (transform.position.x >= targetPosition.position.x && !isSceneLoaded)
//         {
//             // Load the new scene
//             SceneManager.LoadScene("frogger_dungeon");
//             isSceneLoaded = true;
//         }
//     }
// }
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Transform target;
    public string sceneName;

    void Update()
    {
        if (transform.position == target.position)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}