using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ScoreManagerFinal : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + ScoreManager.instance.score.ToString();
        highScoreText.text = "HighScore: " + ScoreManager.instance.highScore.ToString();
    }
}