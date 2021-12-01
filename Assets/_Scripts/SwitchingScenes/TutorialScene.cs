using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        GameObject.FindGameObjectWithTag("Music").GetComponent<MenuMusic>().StopMusic();
    }
}
