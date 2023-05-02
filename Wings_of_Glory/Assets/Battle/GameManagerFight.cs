using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerFight : MonoBehaviour
{
    public Toby toby;
    public Toby_stats toby_stats;
    public static string armor;
    public  int strength = APITest.strength;
    public  int shield = APITest.shield;
    public  int speed = APITest.speed;
    public  int agility = APITest.agility;
    public static int lives;
    public TMP_Text scoreText;
    public static int scoregamemanager;
    public string armorchosengm;
    public int totalScore;
    public ArmorButton armorbutton;
    [SerializeField] APITest api;
    public batteryplayer bp;
    string UN = MenuUser.UiD;
    public static int times_played = 0;
    public GameObject canvasFight;
    //public image stats;
    
    private void Awake()
    {
        //homes = FindObjectsOfType<Home>();
        toby = FindObjectOfType<Toby>();

    }
    public Final_Stats final_stats = new Final_Stats();

    private void Start(){

        
        NewGame();
        // TimesPlayed();
        // Debug.Log("Times played: " + times_played);
        // times_played++;
        

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
        // scoregamemanager=totalScore.score;
        // getstats();
        //Debug.Log(scoregamemanager);
        
        Debug.Log(UN);
        api.GetDataUnity(UN);
        Debug.Log("Strength: " + strength);
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

    
    public void GetDataUnity()
    {
        api.GetDataUnity(UN);
    }


    public void UpdateDataUnity()
    {
        api.UpdateDataUnity(scoregamemanager, UN, agility, strength, shield, speed);
    }
    public void TimesPlayed()
    {
        api.TimesPlayed(UN);
    }
}
