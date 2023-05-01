//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject frog;

    private void OnEnable(){
        frog.SetActive(true);
    }

    private void OnDisable(){
        frog.SetActive(false);
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            enabled = true;
            
            FindObjectOfType<GameManager>().HomeOccupied();
            
        }
    }
}
