//This script is used to randomly select a starting position for Toby in the world;
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobyStartPosition : MonoBehaviour
{
    public List<SpriteRenderer> startPositionOptions;
    public List<SpriteRenderer> startDungeonOptions;
    public GameObject toby;

    void Start()
    {
        // Choose a random SpriteRenderer from the list of options
        SpriteRenderer startPosition = startPositionOptions[Random.Range(0, startPositionOptions.Count)];
        
        // Set Toby's position to the position of the selected SpriteRenderer
        toby.transform.position = startPosition.transform.position;
    }
        
}

