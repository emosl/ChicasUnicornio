using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Frogger frogger;
    private Home[] homes;
    private int score;
    private int lives;
    private int time;
    public GameObject gameOverMenu;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text timeText;

    private void Awake()
    {
        homes = FindObjectsOfType<Home>();
        frogger = FindObjectOfType<Frogger>();
    }
    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        gameOverMenu.SetActive(false);
        SetScore(0);
        SetLives(3);
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

    private void GameOver()
    {
        frogger.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(PlayAgain());

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
        
        if(Cleared())
        {
            SetLives(lives + 1);
            SetScore(score + 1000);
            Invoke(nameof(Newlevel), 1f);
        }
        else
        {
            Invoke(nameof(Respwan), 1f);
        }
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
