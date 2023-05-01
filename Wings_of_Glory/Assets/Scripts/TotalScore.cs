//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalScore : MonoBehaviour
{
    public int score;

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
        Debug.Log("UpdateScore");
        SetScore(points);
    }
}
