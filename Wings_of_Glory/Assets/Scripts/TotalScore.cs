using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalScore : MonoBehaviour
{
    private int score;

    public TMP_Text scoreText;
    public GameManagerToby gameManagerToby;

    void Start()
    {
        int score = 0;
        SetScore(score);
    }

    public void SetScore(int points)
    {
        score += points;
        //this.score = score;
        scoreText.text = score.ToString();
    }

    public void UpdateScore(int points)
    {
        SetScore(points);
        gameManagerToby.SetScore(points);
    }
}
