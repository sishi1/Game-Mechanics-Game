using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameScenes : MonoBehaviour
{
    private void Update()
    {
        Won();
        Lost();
    }
    public void Won()
    {
        if (WaveSpawner.finished) SceneManager.LoadScene("Win");
    }

    public void Lost()
    {
        if (PlayerHealth.death) SceneManager.LoadScene("Lose");
    }
}
