//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Frogger frogger;
    private Home[] homes;
    private int score;
    private int lives;
    private int time;
    public Toby toby;
    public GameObject gameOverMenu;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text timeText;
    private Vector3 lastPlayerPos; 
    public string sceneName;
    public GameObject panel;
    public TobyStartPosition tobyStartPosition;
    public float delayTime = 5.0f;
    public int gameJustStarted;

    private void Awake()
    {
        homes = FindObjectsOfType<Home>();
        frogger = FindObjectOfType<Frogger>();
        // toby = FindObjectOfType<Toby>();
    }
    private void Start()
    {
        panel.SetActive(false);
        NewGame();
        
    
        // if (PlayerPrefs.GetInt("FirstTime", 1) == 1) {
        //     PlayerPrefs.SetInt("FirstTime", 0);
        //     SceneManager.LoadScene("SampleScene");
        // }
        // else {
        //     NewGame();
        // }
        // Scene previousScene = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex - 1);
        // GameObject[] objectsInPreviousScene = previousScene.GetRootGameObjects();

        // foreach (GameObject obj in objectsInPreviousScene)
        // {
        //     toby = obj.GetComponent<Toby>();
        //     if (toby != null)
        //     {
        //         break;
        //     }
        // }
        // lastPlayerPos = toby.transform.position;
    }
    private void NewGame()
    {
        gameOverMenu.SetActive(false);
        SetScore(0);
        SetLives(1);
        Newlevel();
        
    }

    private void Newlevel()
    {
        for(int i = 0; i < homes.Length; i++)
        {
            homes[i].enabled = false;
        }
        Respwan();
        
       
       
    }


    private void Respwan()
    {
        frogger.Respwan();
        StopAllCoroutines();
        StartCoroutine(Timer(30));
        

    }

    private IEnumerator Timer(int duration)
    {
        time = duration;
        timeText.text = time.ToString();
        while(time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
            timeText.text = time.ToString();
        }
       frogger.Death();
    }

    public void Died()
    {
        SetLives(lives - 1);
        if(lives > 0)
        {
            Invoke(nameof(Respwan), 1f);

        }
        else
        {
            Invoke(nameof(GameOver), 1f);
        }
    }

    // private void GameOver()
    // {
    //     frogger.gameObject.SetActive(false);
    //     // gameOverMenu.SetActive(true);
    //     StopAllCoroutines();
    //     // StartCoroutine(PlayAgain());
    //     SceneManager.LoadScene("SampleScene");
    // }

     private void GameOver()
    {
        // Save the current scene name to load it again after the game over
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        frogger.gameObject.SetActive(false);
        StopAllCoroutines();
        //toby.GetComponent<CamerMove>().Start();

        SceneManager.LoadScene("SampleScene");
        // toby.GetComponent<Dungeon>().Scene();
        // Debug.Log("Game Over");
    }

    private IEnumerator PlayAgain()
    {
        bool PlayAgain = false;
        while(!PlayAgain)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                PlayAgain = true;
                
            }
            yield return null;
        }
        NewGame();
    }

    public void AdvancedRow()
    {
        SetScore(score + 10);
    }

    public void HomeOccupied()
{
    frogger.gameObject.SetActive(false);
    int bonusPoints = time * 20;
    SetScore(score + 50);

    if (Cleared())
    {
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        StartCoroutine(WaitAndLoadScene("FinalBattle"));
    }
    else
    {
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        StartCoroutine(WaitAndLoadScene("FinalBattle"));
    }
}

private IEnumerator WaitAndLoadScene(string sceneName)
{
    panel.SetActive(true);
    yield return new WaitForSeconds(delayTime);
    panel.SetActive(false);
    SceneManager.LoadScene(sceneName);
}
    private bool Cleared()
    {
        for(int i = 0; i < homes.Length; i++)
        {
            if(!homes[i].enabled)
            {
                return false;
            }
        }
        return true;
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();
    }
    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
    }
}