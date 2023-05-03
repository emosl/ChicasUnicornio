//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerToby : MonoBehaviour
{
    // public GameObject start_game;
    // public GameObject Toby;
    public Toby toby;
    public Toby_stats toby_stats;
    public static string armor;
    public static int strength;
    public static int shield;
    public static int speed;
    public static int agility;
    public static int lives;
    public TMP_Text scoreText;
    public static int scoregamemanager;
    public string armorchosengm;
    public TotalScore totalScore;
    public ArmorButton armorbutton;
    [SerializeField] APITest api;
    public batteryplayer bp;
    string UN = MenuUser.UiD;
    public static int times_played = 0;
    public GameObject canvasFight;

    public static int currentMapIndex = 0;
    public static bool gameJustStarted = true;

    private Dictionary<string, int> spriteNameToMapIndex;

    //public image stats;
    public class Final_Stats
    {
        // public string chosenarmor;
        public int strength;
        public int shield;
        public int speed;
        public int agility;
    }
    
    private void Awake()
    {
        //homes = FindObjectsOfType<Home>();
        toby = FindObjectOfType<Toby>();

        spriteNameToMapIndex = new Dictionary<string, int>
        {
            { "pos1", 1 },
            { "pos2", 2 },
            { "pos3", 3 },
            { "pos4", 4 }
        };

    }
    public Final_Stats final_stats = new Final_Stats();

    private void Start(){

        
        NewGame();
        TimesPlayed();
        Debug.Log("Times played: " + times_played);
        times_played++;
        

        // strength = final_stats.strength;
        // shield = final_stats.shield;
        // speed = final_stats.speed;
        // agility = final_stats.agility;
    }
    private void NewGame()
    {
        //gameOverMenu.SetActive(false);
        //SetLives(1);
        //SetArmor();
    }
    void Update()
    {
        //This line takes the score from TotalScore.cs and stores it in a variable. Will be used in API
        //debug
        scoregamemanager=totalScore.score;
        getstats();
        //Debug.Log(scoregamemanager);
        
        UpdateDataUnity();
        // Debug.Log(UN);
        getstats();
        // Debug.Log(gadgetlist[2]);
        //Debug.Log(armorchosen);
        
    }

    //Gets final stats for Toby used in DataBase.
    public void getstats(){
        //DEBUGS
        strength = toby.strength;
        shield = toby.shield;
        speed = toby.speed;
        agility = toby.agility;


    }

    public void SetCurrentMapIndexFromSpriteName(string spriteName)
    {
        if (spriteNameToMapIndex.ContainsKey(spriteName))
        {
            currentMapIndex = spriteNameToMapIndex[spriteName];
            Debug.Log("Current map index set to: " + currentMapIndex + " for sprite name: " + spriteName);
        }
        
        else
        {
            Debug.LogError("Invalid sprite name: " + spriteName);
        }
    }

    
    //armor string comes form script ArmorButton.cs
    // public void SetArmor(){
    //     armorchosengm=armorbutton.armorchosen;
    //     Debug.Log(armorchosengm);
    //     //variable sent to the API.
    //     //api.UpdateData();
    //     if(armorchosengm == "pink"){
    //         bp.pink();
    //     }
    //     if(armorchosengm == "blue"){
    //         bp.blue();
    //     }
    //     if(armorchosengm == "red"){
    //         bp.red();
    //     }
    // }

    //Registers when Toby loses all of his lives.
    // private void GameOver()
    // {
    //     // Save the current scene name to load it again after the game over
    //     PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
    //     toby.gameObject.SetActive(false);
    //     StopAllCoroutines();
    //     SceneManager.LoadScene("SampleScene");
    //     //When gameover the finalscore is sent to API
    //     //score= <TotalScore>().SetScore(0);
    // }
 
    // private void SetLives(int lives)
    // {
    //    // this.lives = lives;
    //     // livesText.text = lives.ToString();
    // }


    public void UpdateDataUnity()
    {
        api.UpdateDataUnity(scoregamemanager, UN, agility, strength, shield, speed);
    }
    public void TimesPlayed()
    {
        api.TimesPlayed(UN);
    }
}
