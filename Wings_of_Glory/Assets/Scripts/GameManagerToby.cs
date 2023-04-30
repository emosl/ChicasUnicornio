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
    //public image stats;
    private void Awake()
    {
        //homes = FindObjectsOfType<Home>();
        toby = FindObjectOfType<Toby>();

    }
    private void Start(){
        NewGame();
        TimesPlayed();
        times_played++;
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
        api.UpdateDataUnity(scoregamemanager, UN, agility);
    }
    public void TimesPlayed()
    {
        api.TimesPlayed(UN);
    }
}
