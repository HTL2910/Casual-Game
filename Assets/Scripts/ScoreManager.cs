using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   public static ScoreManager instance;
    private TextMeshProUGUI scoreText;
    public int score = 10;
    private void Awake()
    {
        instance = this;
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        AddScore(0);
    }
    private void Update()
    {
        if (scoreText != null)
        {

        }
        else
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            scoreText.text=score.ToString();
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
        if(score>PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }    
        scoreText.text=score.ToString() ;
    }    
    public void ResetScore()
    {
        score = 0;
    }

}
