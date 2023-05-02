/*
Switch to another scene in the project

Gilberto Echeverria
*/
//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene("Title");
    }
}
