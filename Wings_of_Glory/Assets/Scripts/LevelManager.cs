using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
    
    public GameObject[] levels; // an array of game objects that represent your levels
    private int currentLevelIndex; // the index of the current level

    void Start () {
        currentLevelIndex = 0; // start with the first level
        LoadCurrentLevel();
    }

    void LoadCurrentLevel () {
        // Disable all levels except the current one
        for (int i = 0; i < levels.Length; i++) {
            if (i == currentLevelIndex) {
                levels[i].SetActive(true);
            } else {
                levels[i].SetActive(false);
            }
        }
    }

    public void LoadNextLevel () {
        // Increment the level index and load the next level
        currentLevelIndex++;
        if (currentLevelIndex >= levels.Length) {
            currentLevelIndex = 0; // start over if we've reached the end of the array
        }
        LoadCurrentLevel();
    }
}

