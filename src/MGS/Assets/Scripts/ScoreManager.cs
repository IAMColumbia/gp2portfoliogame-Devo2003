using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int setScore;
    // Start is called before the first frame update
    void Start()
    {
        setScore = 2000;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + setScore;
    }
}
