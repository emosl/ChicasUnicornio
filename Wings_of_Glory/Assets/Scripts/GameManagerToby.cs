using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerToby : MonoBehaviour
{
    public GameObject start_game;
    public GameObject Toby;
    public Toby toby;
    public static string armor;
    public static int strength;
    public static int shield;
    public static int speed;
    public static int agility;
    public static int lives;
    public TMP_Text scoreText;
    //public image stats;

    public List<int> gadgetlist = new List<int>();
    public List<int> killerspritelist = new List<int>();


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
        SetScore(0);
        SetLives(1);
        //SetArmor();
    }



    //çpublic static void 
    private void SetScore(int score)
    {
        //this.score = score;
        scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
       // this.lives = lives;
        // livesText.text = lives.ToString();
    }
//This function stores the gadget_id in a list for the API
//
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



    void Update()
    {
        // Add code here to update the game state
    }

    // public void GetArmor(){
    //     api.UpdateData();
    // }
}
