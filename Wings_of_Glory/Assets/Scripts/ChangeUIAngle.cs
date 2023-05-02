//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
/*
Change a numerical value using buttons and
store it using PlayerPrefs

GIlberto Echeverria
*/

using UnityEngine;
using UnityEngine.UI;

public class ChangeUIAngle : MonoBehaviour
{
    [SerializeField] Text display;

    float angle = 0.0f;

    void Start()
    {
        angle = PlayerPrefs.GetFloat("Angle", 0.0f);
        display.text = angle.ToString();
    }

    public void ChangeValue(float value)
    {
        angle += value;
        display.text = angle.ToString();
        PlayerPrefs.SetFloat("Angle", angle);
    }
}
