using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public Text ScoreText;
    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        GetData();
    }
    public void IncrementScore()
    {
        score++;
        ScoreText.text = "Score: " + score;
        if (score > highScore)
        {
            highScore = score;
            SaveData();
        }
    }
    public void AggroIncrementScore()
    {
        score = score + 5;
        ScoreText.text = "Score: " + score;
    }
    public void SaveData()
    {
        //PlayerPrefs.SetInt("highscore",score);
        string filePath = UnityEngine.Application.persistentDataPath + "/PlayerScore.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(highScore); // Saving Highscore
        fs.Close();
        bw.Close();
    }
    public void GetData()
    {
        string filePath = Application.persistentDataPath + "/PlayerScore.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryReader br = new BinaryReader(fs);

        highScore = (br.ReadInt32());
        fs.Close();
        br.Close();

    }
}
