using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int scoreAddOn = 1;
    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText.text = "Score : ";
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore()
    {
        score = score + scoreAddOn;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score : "+score;
    }

    public void ScoreMultiplier()
    {
        scoreAddOn = scoreAddOn * 2;
    }
    public void ScoreDemultiplier()
    {
        scoreAddOn = scoreAddOn / 2;
    }
}
