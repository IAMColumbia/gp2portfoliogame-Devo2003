using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    //public static ScoreManager instance;
    public TMP_Text scoreText;
    public TMP_Text HighscoreText;
    //public TMP_Text LowcoreText;
    public int startingScore = 1000;



    // Start is called before the first frame update
    void Start()
    {
        Score.CurrentScore = startingScore;
        scoreText.text = "Score: " + Score.CurrentScore.ToString();
        HighscoreText.text = "HighScore: " + Score.HighScore.ToString();
        //setScore = 2000;


        //public static void UpdateScore(int newScore)
        //{
        //    CurrentScore = newScore;
        //    if (newScore > HighScore)
        //    {
        //        HighScore = newScore;
        //    }
        //}


    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score.CurrentScore.ToString();

        
        Score.UpdateScore();

        //int scoreToAdd = Mathf.RoundToInt(timer); // Each remaining second adds 1 point
        //Score.AddScore(scoreToAdd);
        //scoreText.text = "HighScore: " + Score.HighScore.ToString();
        //scoreText.text = Score.CurrentScore.ToString();
        //scoreText.text = "Score: " + setScore;
    }
}
