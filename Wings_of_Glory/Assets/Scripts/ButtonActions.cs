//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
/*
Callbacks for buttons
Used to test the API interaction from other scripts

Gilberto Echeverria
*/

using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    //[SerializeField] GameObject apiObject;
    //APITest api;

    [SerializeField] APITest api;

    void Start()
    {
        //api = apiObject.GetComponent<APITest>();
    }

    public void GetUsers()
    {
        api.QueryUsers();
    }

    public void AddUser()
    {
        api.InsertNewUser();
    }
}
