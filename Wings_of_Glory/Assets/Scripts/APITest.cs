/*
Test for the connection to an API
Able to use the Get method to read data and "Post" to send data
NOTE: Using Put instead of Post. See the links around line 86

Gilberto Echeverria
2023-04-12
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


// Create classes that correspond to the data that will be sent/received
// via the API

// Allow the class to be extracted from Unity
// https://stackoverflow.com/questions/40633388/show-members-of-a-class-in-unity3d-inspector
[System.Serializable]
public class Users
{
    public int username_ID;
    public string name;
    public string last_name;
    public string email;
    public string password;
}

public class highscores
{
    // public int score_ID;
    public int username_ID;
    public int total_score;
    // public int score_speed;
    // public int score_strength;
    // public int score_agility;
    // public int score_shield;

}
// Allow the class to be extracted from Unity
[System.Serializable]
public class UserList
{
    public List<Users> users;
}
public class ScoreList
{
    public List<highscores> highscores;
}


public class APITest : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getUsersEP;
    [SerializeField] string putUsersEP;
    [SerializeField] Text errorText;

    // This is where the information from the api will be extracted
    public UserList allUsers; //variable con la lista de usuarios
    public ScoreList allScores; //variable con la lista de scores

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space)) {
            QueryUsers();
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            InsertNewUser();
        }
        */
        //para checarlo
    }

    // Show the results of the Query in the Unity UI elements,
    // via another script that fills a scrollview
    void DisplayUsers()
    {
        TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadNames(allUsers);
    }

    void DisplayScores()
    {
        TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadScores(allScores);
    }

    // These are the functions that must be called to interact with the API

    public void QueryUsers()
    {
        StartCoroutine(GetUsers());
        //corre un metodo en paralelo y espera a que termine
    }

    public void QueryScores()
    {
        StartCoroutine(GetScores());
        //corre un metodo en paralelo y espera a que termine
    }

    public void InsertNewUser()
    {
        StartCoroutine(AddUser());
    }

    public void InsertNewScore()
    {
        StartCoroutine(AddScore());
    }

    ////////////////////////////////////////////////////
    // These functions make the connection to the API //
    ////////////////////////////////////////////////////

    //IEnumerator es un tipo de dato que permite hacer un metodo en paralelo, es un generador, un metodo que se ejecuta en paralelo

    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP))
        //crea un request de tipo get, y le pasa la url
        {
            yield return www.SendWebRequest();
            //espera a que termine el request (await)

            if (www.result == UnityWebRequest.Result.Success) {
                //Debug.Log("Response: " + www.downloadHandler.text);
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString = "{\"users\":" + www.downloadHandler.text + "}";
                allUsers = JsonUtility.FromJson<UserList>(jsonString); //nuevo objeto con la lista de usuarios
                DisplayUsers();
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator GetScores()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP))
        //crea un request de tipo get, y le pasa la url
        {
            yield return www.SendWebRequest();
            //espera a que termine el request (await)

            if (www.result == UnityWebRequest.Result.Success) {
                //Debug.Log("Response: " + www.downloadHandler.text);
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString = "{\"scores\":" + www.downloadHandler.text + "}";
                allScores = JsonUtility.FromJson<ScoreList>(jsonString); //nuevo objeto con la lista de usuarios
                DisplayScores();
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }


    IEnumerator AddUser()
    {
        /*
        // This should work with an API that does NOT expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        Users testUser = new Users();
        testUser.name = "newGuy" + Random.Range(1000, 9000).ToString();
        testUser.last_name= "Tester" + Random.Range(1000, 9000).ToString();
        testUser.email = "newGuy" + Random.Range(1000, 9000).ToString() + "@mail.com";
        testUser.password = "1234";

        //Debug.Log("USER: " + testUser);
        string jsonData = JsonUtility.ToJson(testUser);
        //Debug.Log("BODY: " + jsonData);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        using (UnityWebRequest www = UnityWebRequest.Put(url + putUsersEP, jsonData))
        {
            //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
            // Set the method later, and indicate the encoding is JSON
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }


    ////////////////////////////////////////////////////
    // These functions allow making a callback after the API request finishes
    ////////////////////////////////////////////////////

    // Test function to get a response and act accordingly
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html
    public void GetResults()
    {
        UserList localUsers;
        // Call the IEnumerator and pass a lambda function to be called
        StartCoroutine(GetUsersString((reply) => {
                localUsers = JsonUtility.FromJson<UserList>(reply);
                DisplayUsers();
        }));
    }

    // Sending the data back to the caller of the Coroutine, using a callback
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html
    IEnumerator GetUsersString(System.Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                //Debug.Log("Response: " + www.downloadHandler.text);
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString = "{\"users\":" + www.downloadHandler.text + "}";
                callback(jsonString);
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }
}
