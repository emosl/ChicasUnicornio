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
    public List<int> gadgetlist = new List<int>();
    public List<int> killerspritelist = new List<int>();
    public Toby toby;
    public static string armor;
    public static int strength;
    public static int shield;
    public static int speed;
    public static int agility;
    public static int lives;
    public TMP_Text scoreText;
    public int scoregamemanager;
    public string armorchosengm;
    public TotalScore totalScore;
    public ArmorButton armorbutton;
    
    //public TotalScore score;
    public batteryplayer bp;
    //public image stats;
    private void Awake()
    {
        //homes = FindObjectsOfType<Home>();
        toby = FindObjectOfType<Toby>();

    }
    private void Start(){
        NewGame();
    }
    private void NewGame()
    {
        //gameOverMenu.SetActive(false);
        //SetLives(1);
        SetArmor();
    }
    void Update()
    {
        //This line takes the score from TotalScore.cs and stores it in a variable. Will be used in API
        scoregamemanager=totalScore.score;
        getstats();

        //Debug.Log(armorchosen);
        
    }

    //Gets final stats for Toby used in DataBase.
    public void getstats(){
        strength = toby.strength;
        shield = toby.shield;
        speed = toby.speed;
        agility = toby.agility;
    }
    //armor string comes form script ArmorButton.cs
    public void SetArmor(){
        armorchosengm=armorbutton.armorchosen;
        Debug.Log(armorchosengm);
        //variable sent to the API.
        //api.UpdateData();
        if(armorchosengm == "pink"){
            bp.pink();
        }
        if(armorchosengm == "blue"){
            bp.blue();
        }
        if(armorchosengm == "red"){
            bp.red();
        }
    }

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

 //This function stores the gadget_id in a list for the API
 //THis function is  in ItemPickup PanelScript when an obstacle is added.
    public void GadgetCounter(string gadget)
    {
        if (gadget == "Carrot")
        {
            gadgetlist.Add(121);
        }
        else if (gadget == "FireShoe")
        {
            gadgetlist.Add(122);
        }
        else if (gadget == "Silver")
        {
            gadgetlist.Add(123);
        }
        else if (gadget == "SpikeShoe")
        {
            gadgetlist.Add(124);
        }
        else if (gadget == "Hairband")
        {
            gadgetlist.Add(125);
        }
        else if (gadget == "Manzana")
        {
            gadgetlist.Add(126);
        }
        else if (gadget == "Oro")
        {
            gadgetlist.Add(127);
        }
        else if (gadget == "Crown")
        {
            gadgetlist.Add(128);
        }
        else if (gadget == "Hat")
        {
            gadgetlist.Add(129);
        }
        else if (gadget == "Headband")
        {
            gadgetlist.Add(1201);
        }
        else if (gadget == "RollerShoe")
        {
            gadgetlist.Add(1202);
        }
        else if (gadget == "Bronze")
        {
            gadgetlist.Add(1203);
        }
    }

   //This function stores the killersprite_id in a list for the API
// The string stored comes from ObstacleImplementation. When a killersprite is passed, the name is stored in the list.
    public void KillerSpriteCounter(string killersprite)
    {
        if (killersprite == "Bomb")
        {
            killerspritelist.Add(131);
        }
        else if (killersprite == "Water")
        {
            killerspritelist.Add(132);
        }
        else if (killersprite == "Ice")
        {
            killerspritelist.Add(133);
        }
        else if (killersprite == "Rock")
        {
            killerspritelist.Add(134);
        }
    }

    void Start()
    {
        // Add code here to initialize the game state
    }

}
