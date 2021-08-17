using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public int score = 0;
    public void IncrementScore()
    {
        score++;
        ScoreText.text = "Score: " + score;
    }
    private void Start()
    {
    }
}