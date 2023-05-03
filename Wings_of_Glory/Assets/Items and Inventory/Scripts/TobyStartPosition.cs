// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TobyStartPosition : MonoBehaviour
// {
//     public List<SpriteRenderer> startPositionOptions;
//     public GameObject toby;

//     void Start()
//     {
//         // Choose a random SpriteRenderer from the list of options
//         SpriteRenderer startPosition = startPositionOptions[Random.Range(0, startPositionOptions.Count)];
        
//         // Set Toby's position to the position of the selected SpriteRenderer
//         toby.transform.position = startPosition.transform.position;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobyStartPosition : MonoBehaviour
{
    public List<SpriteRenderer> startPositionOptions;
    public GameManagerToby gameManagerToby;
    public GameObject toby;

    void Start()
    {
        // Choose a random SpriteRenderer from the list of options
        SpriteRenderer startPosition = startPositionOptions[Random.Range(0, startPositionOptions.Count)];
        
        // Set Toby's position to the position of the selected SpriteRenderer
        toby.transform.position = startPosition.transform.position;

        // Set the current map index in GameManagerToby
        gameManagerToby.SetCurrentMapIndexFromSpriteName(startPosition.name);
    }
}
