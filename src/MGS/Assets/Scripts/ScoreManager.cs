using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TMP_Text scoreText;
    public int setScore;

    private void Awake()
    {
        if (instance == null)
        {
            //this = ScoreManager
            instance = this;
        }
        else
        {
            //if another instance of the ScoreManager is created get rid of it
            Destroy(instance);
        }
    }
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
