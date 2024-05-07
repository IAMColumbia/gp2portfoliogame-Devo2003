using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text HighscoreText;
    public TMP_Text TotalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Score.totalScore = Score.CurrentScore;
        Score.CurrentScore = Score.startingScore;
        scoreText.text = "Score: " + Score.CurrentScore.ToString();
        HighscoreText.text = "HighScore: " + Score.HighScore.ToString();
        TotalScoreText.text = "TotalScore: " + Score.totalScore.ToString();    
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score.CurrentScore.ToString();
        Score.UpdateScore();
    }
}
