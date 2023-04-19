
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class StatsDisplay : MonoBehaviour
// {
//     public Text NameText;
//     public Text ValueText;
//     public Stats Stat { get; set; }


//     private void OnValidate()
//     {
//         Text[] texts = GetComponentsInChildren<Text>();
//         if (texts.Length >= 2)
//         {
//             NameText = texts[0];
//             ValueText = texts[1];
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this namespace for TextMeshPro

public class StatsDisplay : MonoBehaviour
{
    public TMP_Text NameText; // Change this to TMP_Text
    public TMP_Text ValueText; // Change this to TMP_Text
    public Stats Stat { get; set; }

    private void OnValidate()
    {
        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>(); // Change this to TMP_Text
        if (texts.Length >= 2)
        {
            NameText = texts[0];
            ValueText = texts[1];
        }
    }
}
