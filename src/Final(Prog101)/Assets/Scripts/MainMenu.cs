using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ButtonforStart()
    {
        SceneManager.LoadScene("Game");
        print("button pressed");
    }
    public void ButtonforOptions()
    {
        SceneManager.LoadScene("Options");
        print("button pressed");
    }
    public void ButtonforCredits()
    {
        SceneManager.LoadScene("Credits");
        print("button pressed");
    }

    

}
