//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// This is a C# script defining a class called GameManagerFight that inherits from MonoBehaviour.
public class GameManagerFight : MonoBehaviour
{
    // These are public integer fields for mule strength, shield, speed and agility.
    public int mule_strength;
    public int mule_shield;
    public int mule_speed;
    public int mule_agility;

    // This is a private field of type APITest, serialized so it can be viewed in the Inspector.
    [SerializeField] APITest api;

    // This is a public field of type batteryplayerfight.
    public batteryplayerfight bpf;

    // This is a string variable UN with the value from MenuUser.UiD.
    string UN = MenuUser.UiD;

    // These are public fields of type GameObject, used to reference UI menus.
    public GameObject GameOverMenu;
    public GameObject WinMenu;

    // These are public fields of type TobyBattle, MulaBattle, and a static integer times_played.
    public TobyBattle tobyBattle;
    public MulaBattle mulaBattle;
    public static int times_played = 0;

    // This is a public field of type GameObject and an integer TobySum.
    public GameObject canvasFight;
    public int TobySum;

    // This is a public integer MuleSum and two game objects pushingObject and receivingObject, 
    // along with a float pushForce and a boolean isPushing.
    public int MuleSum;
    public GameObject pushingObject;
    public GameObject receivingObject;
    public float pushForce = 10f;
    private bool isPushing = false;


    private void Start()
    {
        // These lines set GameOverMenu and WinMenu to inactive, get the data from API and call MuleStats() and TobyStats().
        GameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        api.GetDataUnity(UN);
        MuleStats();
        // bpf.ChangeSpeed(APITest.speed);
        // bpf.ChangeStrength(APITest.strength);
        // bpf.ChangeShield(8);
        TobyStats();
        // toby = FindRigidbody2D("Toby");
        
    }

    void Update()
    {
        // This method sets TobySum as a sum of all stats values for Toby from the get of the API
        TobySum = 0 + APITest.strength + APITest.shield + APITest.speed + APITest.agility;

        // If TobySum is less than 40, print debug information about TobySum, MuleSum, mule_speed, TobySpeed, and TobyAgility.
        if (TobySum < 40)
        {
            Debug.Log("TobySum-40: " + TobySum);
            Debug.Log("Mule-40: " + MuleSum);
            Debug.Log("MULESPEED:"+ mule_speed);
            Debug.Log("TobySpeed:" + APITest.speed);
            Debug.Log("TobyAgility:" + APITest.agility);
        }
        DeterminePushWinner();
    }

    // This method gets data from API.
    public void GetDataUnity()
    {
        api.GetDataUnity(UN);
    }

    // This method calculates mule stats based on API data and random boosts between 10 and 25 points.
    public void MuleStats()
    {
        int rand = Random.Range(10, 25);
        mule_agility = APITest.agility + rand;
        mule_strength = APITest.strength + rand;
        mule_shield = APITest.shield + rand;
        mule_speed = APITest.speed + rand;
        MuleSum = mule_agility + mule_strength + mule_shield + mule_speed;
    }

    // This method sets Toby stats.
    public void TobyStats()
    {
        // toby.agility = APITest.agility;
        // toby.strength = APITest.strength;
        // toby.shield = APITest.shield;
        // toby.speed = APITest.speed;
        TobySum = 0 + APITest.strength + APITest.shield + APITest.speed + APITest.agility;
        //Changes health bars of Toby.
        // bpf.ChangeStrength(APITest.strength);
        // bpf.ChangeShield(APITest.shield);
        // bpf.ChangeSpeed(APITest.speed);
        // bpf.ChangeAgility(APITest.agility);

    }

    private void FixedUpdate()
    {
        // If isPushing is true, this method calculates the push direction and applies push using two game objects.
        if (isPushing)
        {
            Vector3 pushDirection = (receivingObject.transform.position - pushingObject.transform.position).normalized;
            receivingObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushForce, ForceMode2D.Force);
        }
    }

    public void DeterminePushWinner()
    {
        // If TobySum is greater than MuleSum, reduce TobySum by 20, set myInt as APITest speed, 
        // find the game object 'Toby', set a float value for tobyBattle.PushEnemy, start mula battle and enable pushing.
        if (TobySum > MuleSum)
        {
            TobySum = TobySum - 20;
            int myInt = APITest.speed;
            float myFloat = (float)myInt;
            pushingObject = GameObject.Find("Toby");
            receivingObject = GameObject.FindGameObjectWithTag("Enemy");
            tobyBattle.PushEnemy(myFloat);
            mulaBattle.Start();
            isPushing = true;
        }
        // If TobySum is less than or equal to MuleSum, set myInt as mule_speed, 
        // find the game object with tag 'Enemy', set a float value for mulaBattle.PushMule and enable pushing.
        else
        {
            int myInt = mule_speed;
            float myFloat = (float)myInt;
            pushingObject = GameObject.FindGameObjectWithTag("Enemy");
            receivingObject = GameObject.Find("Toby");
            mulaBattle.PushMule(myFloat);
            isPushing = true;
        }
    }

    public void GameOver()
    {
        // This method sets both TobyBattle and MulaBattle game objects to inactive, and starts a coroutine to restart the game.
        tobyBattle.gameObject.SetActive(false);
        mulaBattle.gameObject.SetActive(false);
        Debug.Log("Game Over");
        tobyBattle.gameObject.SetActive(false);
        GameOverMenu.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        // This coroutine waits for user input then loads the Start_Scene.
        bool playAgain = false;
        while (!playAgain)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playAgain = true;
            }
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Start_Scene");
    }

    public void WinGame()
    {
        // This method sets both TobyBattle and MulaBattle game objects to inactive, and starts a coroutine to restart the game.
        tobyBattle.gameObject.SetActive(false);
        mulaBattle.gameObject.SetActive(false);
        Debug.Log("Game Over");
        tobyBattle.gameObject.SetActive(false);
        WinMenu.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(RestartGame());
    }
}
