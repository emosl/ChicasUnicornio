//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
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
public class Username
{
    public string name;
    // public int username_ID;  
}

public class SavedData
{
    public string username_ID;
    public int total_score;
    public int times_played;
    public int score_agility;
    public int score_strength;
    public int score_shield;
    public int score_speed;
    
}
public class Gadget
{
    public int gadgetid;
}
public class KillSprite
{
    public int killersprite_Id;
}

public class TimesPlayed
{
    public int times_played;
}
public class Checkpoint
{
    public int checkpoint;
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
public class UsernameList
{
    public List<Username> names;
}
public class TimesPlayedList
{
    public List<TimesPlayed> times_played;
}


public class APITest : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getUsersEP;
    [SerializeField] string getUserEP;
    [SerializeField] string putUsersEP;
    [SerializeField] string getScoresEP;
    [SerializeField] string putScoresEP;
    [SerializeField] string putSavedDataEP;
    [SerializeField] string insertGadgetEP;
    [SerializeField] string insertKillSpriteEP;
    [SerializeField] string getTimesPlayedEP;
    [SerializeField] string getSavedDataEP;
    [SerializeField] string getCheckpointEP;
    [SerializeField] Text errorText;

    public static int strength;
    public static int shield;
    public static int speed;
    public static int agility;
    public static int total_score; 
    string UN = MenuUser.UiD;
    string UN2;
    int TS = GameManagerToby.scoregamemanager;
    int TS2;
    int ag_score;
    int st_score;
    int sh_score;
    int sp_score;
    int tp;
    int gadget2;
    int killer2;
    int checkpoint2;
    // int TP = GameManagerToby.timesPlayed;

    private GameManagerToby gameManager;

    // This is where the information from the api will be extracted
    public UserList allUsers; //variable con la lista de usuarios
    public ScoreList allScores; //variable con la lista de scores
    public Username allUsername; 
    public TimesPlayed allTimesPlayed;
    public SavedData allSavedData;
    public Checkpoint allCheckpoint;

     void Start()
    {
        // Get a reference to the GameManagerToby script
        gameManager = GameObject.FindObjectOfType<GameManagerToby>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    // Show the results of the Query in the Unity UI elements,
    // via another script that fills a scrollview
    void DisplayUsers()
    {
        TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadNames(allUsers);
    }
    void DisplayUser()
    {
        TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadUsername(allUsername);
    }

    void DisplayScores()
    {
        TMPro_Test texter = GetComponent<TMPro_Test>();
        // texter.LoadScores(allScores);
    }

    // These are the functions that must be called to interact with the API

    public void QueryUsers()
    {
        StartCoroutine(GetUsers());
        //corre UN2 metodo en paralelo y espera a que termine
    }
    public void QueryUser(string UiD)
    {
        UN2 = UiD;
        StartCoroutine(GetUser());
        // Debug.Log(UN2);
        // Debug.Log("QueryUser");
        //corre un metodo en paralelo y espera a que termine
    }
    public void TimesPlayed(string UiD)
    {
        UN2 = UiD;
        StartCoroutine(GetTimesPlayed());
    }
    public void UpdateData()
    {
        StartCoroutine(UpdateSavedData());
    }
    public void UpdateDataUnity(int totalScore, string UiD, int agility, int strength, int shield, int speed)
    {
        UN2 = UiD;
        TS2 = totalScore;
        ag_score = agility;
        st_score = strength;
        sh_score = shield;
        sp_score = speed;
        
        StartCoroutine(UpdateSavedDataUnity());
        // Debug.Log(TS2);
    }
    public void UpdateGadget(int gadget)
    {
        gadget2 = gadget;
        Debug.Log(gadget);
        StartCoroutine(UpdateGadgetData());
    }
    public void UpdateKillSprite(int killer)
    {
        killer2 = killer;
        Debug.Log(killer);
        StartCoroutine(UpdateKillSpriteData());
    }
    public void GetDataUnity(string UiD)
    {
        UN2 = UiD;
        Debug.Log("USERID: " + UN2);
        StartCoroutine(GetDataFinal());
    }
    public void GetCheckpoint(string UiD)
    {
        UN2 = UiD;
        StartCoroutine(GetCheckpointData());
    }
    public void SetCheckpoint(int checkpoint)
    {
        checkpoint2 = checkpoint;
        StartCoroutine(SetCheckpointData());
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

    IEnumerator GetUser()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUserEP + UN2))
        //crea un request de tipo get, y le pasa la url
        {
            yield return www.SendWebRequest();
            //espera a que termine el request (await)

            if (www.result == UnityWebRequest.Result.Success) {
                //Debug.Log("Response: " + www.downloadHandler.text);
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString =  www.downloadHandler.text;
                // string jsonString = www.downloadHandler.text;
                Debug.Log(jsonString);
                allUsername = JsonUtility.FromJson<Username>(jsonString); //nuevo objeto con la lista de usuarios
                Debug.Log(allUsername.name);
                // Debug.Log("Response: " + www.downloadHandler.text);
                DisplayUser();
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
        Debug.Log("GetUser");
    }


    IEnumerator GetTimesPlayed()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getTimesPlayedEP + UN2))
        //crea un request de tipo get, y le pasa la url
        {
            yield return www.SendWebRequest();
            //espera a que termine el request (await)

            if (www.result == UnityWebRequest.Result.Success) {
                //Debug.Log("Response: " + www.downloadHandler.text);
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString =  www.downloadHandler.text;
                // string jsonString = www.downloadHandler.text;
                Debug.Log(jsonString);
                allTimesPlayed = JsonUtility.FromJson<TimesPlayed>(jsonString); //nuevo objeto con la lista de usuarios
                allTimesPlayed.times_played = allTimesPlayed.times_played + 1;
                Debug.Log(allTimesPlayed.times_played);
                // Debug.Log("Response: " + www.downloadHandler.text);
                // DisplayUser();
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
        // Debug.Log("GetUser");
    }

    IEnumerator GetDataFinal()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getSavedDataEP + UN2))
        //crea un request de tipo get, y le pasa la url
        {
            yield return www.SendWebRequest();
            //espera a que termine el request (await)

            if (www.result == UnityWebRequest.Result.Success) {
                //Debug.Log("Response: " + www.downloadHandler.text);
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString =  www.downloadHandler.text;
                // string jsonString = www.downloadHandler.text;
                Debug.Log("JSON" + jsonString);
                allSavedData= JsonUtility.FromJson<SavedData>(jsonString); //nuevo objeto con la lista de usuarios
                // allSavedData.score_agility = allTimesPlayed.score_agility;
                strength = allSavedData.score_strength;
                agility = allSavedData.score_agility;
                speed = allSavedData.score_speed;
                shield = allSavedData.score_shield;
                Debug.Log("agility " + allSavedData.score_agility);
                // Debug.Log("Response: " + www.downloadHandler.text);
                // DisplayUser();
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }    

    IEnumerator GetCheckpointData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getCheckpointEP + UN2))
        //crea un request de tipo get, y le pasa la url
        {
            yield return www.SendWebRequest();
            //espera a que termine el request (await)

            if (www.result == UnityWebRequest.Result.Success) {
                //Debug.Log("Response: " + www.downloadHandler.text);
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString =  www.downloadHandler.text;
                // string jsonString = www.downloadHandler.text;
                Debug.Log("JSON" + jsonString);
                allCheckpoint= JsonUtility.FromJson<SavedData>(jsonString); //nuevo objeto con la lista de usuarios
                // allSavedData.score_agility = allTimesPlayed.score_agility;
                Debug.Log("checkpoint " + allCheckpoint.checkpoint);
                // Debug.Log("Response: " + www.downloadHandler.text);
                // DisplayUser();
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

    IEnumerator UpdateSavedData()
    {
        // Create the object to be sent as json
        SavedData testData = new SavedData();
        testData.username_ID = UN2;
        testData.total_score =Random.Range(1000, 9000);
        testData.times_played= Random.Range(1000, 9000);

        // Debug.Log("DATA: " + testData.total_score);
        string jsonData = JsonUtility.ToJson(testData);
        // Debug.Log("BODY: " + jsonData);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        using (UnityWebRequest www = UnityWebRequest.Put(url + putSavedDataEP, jsonData))
        {
            //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
            // Set the method later, and indicate the encoding is JSON
            www.method = "PUT";
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

    IEnumerator SetCheckpointData()
    {
        Checkpoint testData = new Checkpoint();
        testData.checkpoint = checkpoint2;

        // Debug.Log("DATA: " + testData.total_score);
        string jsonData = JsonUtility.ToJson(testData);
        Debug.Log("BODY: " + jsonData);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        using (UnityWebRequest www = UnityWebRequest.Put(url + getCheckpointEP, jsonData))
        {
            //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
            // Set the method later, and indicate the encoding is JSON
            www.method = "PUT";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                // Debug.Log("Response: " + www.downloadHandler.text);
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }
    
    IEnumerator UpdateSavedDataUnity()
    {
        // Create the object to be sent as json
        SavedData testData = new SavedData();
        testData.username_ID = UN2;
        testData.total_score = TS2;
        testData.times_played= allTimesPlayed.times_played;
        testData.score_agility = ag_score;
        testData.score_shield = sh_score;
        testData.score_speed = sp_score;
        testData.score_strength = st_score;

        // Debug.Log("DATA: " + testData.total_score);
        string jsonData = JsonUtility.ToJson(testData);
        Debug.Log("BODY: " + jsonData);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        using (UnityWebRequest www = UnityWebRequest.Put(url + putSavedDataEP, jsonData))
        {
            //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
            // Set the method later, and indicate the encoding is JSON
            www.method = "PUT";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                // Debug.Log("Response: " + www.downloadHandler.text);
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }


    IEnumerator UpdateGadgetData()
    {
        // Create the object to be sent as json
        Gadget testData = new Gadget();
        Debug.Log("DATA1: " + gadget2);
        testData.gadgetid = gadget2;

        Debug.Log("DATA: " + testData.gadgetid);
        string jsonData = JsonUtility.ToJson(testData);
        Debug.Log("BODY: " + jsonData);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        using (UnityWebRequest www = UnityWebRequest.Put(url + insertGadgetEP, jsonData))
        {
            //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
            // Set the method later, and indicate the encoding is JSON
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();
            Debug.Log("DATA3: " + testData.gadgetid);

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }



    IEnumerator UpdateKillSpriteData()
    {
        // Create the object to be sent as json
        KillSprite testData = new KillSprite();
        Debug.Log("KILL1: " + killer2);
        testData.killersprite_Id = killer2;

        Debug.Log("KILL: " + testData.killersprite_Id);
        string jsonData = JsonUtility.ToJson(testData);
        Debug.Log("BODY: " + jsonData);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        using (UnityWebRequest www = UnityWebRequest.Put(url + insertKillSpriteEP, jsonData))
        {
            //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
            // Set the method later, and indicate the encoding is JSON
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();
            Debug.Log("DATA3: " + testData.killersprite_Id);

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }


    IEnumerator AddScore()
    {
        /*
        // This should work with an API that does NOT expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        highscores testScore = new highscores();
        // testScore.username_ID = "newID" + Random.Range(1000, 9000).ToString();
        testScore.total_score=  Random.Range(1000, 9000);
        // testUser.email = "newGuy" + Random.Range(1000, 9000).ToString() + "@mail.com";
        

        //Debug.Log("USER: " + testUser);
        string jsonData = JsonUtility.ToJson(testScore);
        //Debug.Log("BODY: " + jsonData);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        using (UnityWebRequest www = UnityWebRequest.Put(url + getScoresEP, jsonData))
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