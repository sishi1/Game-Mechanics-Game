﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Highscore()
    {
        SceneManager.LoadScene("Highscore");
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
