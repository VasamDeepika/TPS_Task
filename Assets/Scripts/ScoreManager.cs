using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text ScoreText;
    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void IncrementScore()
    {
            score++;
            ScoreText.text = "Score: " + score;
    }
    public void AggroIncrementScore()
    {
        score = score+5;
        ScoreText.text = "Score: " + score;
    }
}
