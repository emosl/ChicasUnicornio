// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;

// public class LevelManager : MonoBehaviour {
    
//     public GameObject[] levels; // an array of game objects that represent your levels
//     private int currentLevelIndex; // the index of the current level

//     void Start () {
//         currentLevelIndex = 0; // start with the first level
//         LoadCurrentLevel();
//     }

//     void LoadCurrentLevel () {
//         // Disable all levels except the current one
//         for (int i = 0; i < levels.Length; i++) {
//             if (i == currentLevelIndex) {
//                 levels[i].SetActive(true);
//             } else {
//                 levels[i].SetActive(false);
//             }
//         }
//     }

//     public void LoadNextLevel () {
//         // Increment the level index and load the next level
//         currentLevelIndex++;
//         if (currentLevelIndex >= levels.Length) {
//             currentLevelIndex = 0; // start over if we've reached the end of the array
//         }
//         LoadCurrentLevel();
//     }
// }
//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string[] levelNames; // An array to hold the names of all the levels/scenes
    public GameObject[] levels;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.CompareTag("LevelChange"))
        // {
        //     // Choose a random level and load it
        //     int randomIndex = Random.Range(0, levelNames.Length);
        //     SceneManager.LoadScene(levelNames[randomIndex]);
        //     tranform.position = new Vector3(level[rand].tanform.poisition);
        // }
    }
}
