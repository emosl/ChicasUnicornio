// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TobyStartPosition : MonoBehaviour
// {
//     public List<SpriteRenderer> startPositionOptions;
//     public List<SpriteRenderer> startDungeonOptions;
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
    public List<SpriteRenderer> startDungeonOptions;
    public GameObject toby;

    public static int selectedStartIndex; // Store the index of the selected starting position

    void Start()
    {
        SpriteRenderer startPosition = startPositionOptions[Random.Range(0, startPositionOptions.Count)];
        selectedStartIndex = startPositionOptions.IndexOf(startPosition);
        Debug.Log("map" + selectedStartIndex);
        toby.transform.position = startPosition.transform.position;

    }
}
