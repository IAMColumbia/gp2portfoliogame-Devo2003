using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class TimeManager : MonoBehaviour
{
    public float bestTime;
    public float timeLimit;
    public float timer;
    public TMP_Text TimeText;
    public TMP_Text BestTimeText;

    // Start is called before the first frame update
    void Start()
    {
        timeLimit = 121;
        timer = timeLimit;

        //bestTime = 90;

        //UpdateTime();

        bestTime = PlayerPrefs.GetFloat("BestTime", 90f);
        UpdateBestTimeText();
    }


    // Update is called once per frame
    void Update()
    {
        

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Timer();
        }
        else
        {
            TimesUp();
        }
        
       
    }



    public void Timer()
    {
        timer -= Time.deltaTime;

        int mins = Mathf.FloorToInt(timer / 60);
        int secs = Mathf.FloorToInt(timer % 60);
        TimeText.text = "Time Limit: " + string.Format("{0:00}:{1:00}", mins, secs);
    }

    public void UpdateTime()
    {
        //if (timer > bestTime)
        //{
        //    bestTime = timer;

        //    PlayerPrefs.SetFloat("BestTime", bestTime);
        //}
    }

    public void TimesUp()
    {
        if (timer < bestTime)
        {
            bestTime = timer;

            PlayerPrefs.SetFloat("BestTime", bestTime);
            UpdateBestTimeText();
        }

        SceneManager.LoadScene("Finished");
    }

    // Method to update the best time text
    public void UpdateBestTimeText()
    {
        BestTimeText.text = "Best Time: " + FormatTime(bestTime);
    }

    // Utility method to format time as MM:SS
    string FormatTime(float timeInSeconds)
    {
        int mins = Mathf.FloorToInt(timeInSeconds / 60);
        int secs = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", mins, secs);
    }
}
