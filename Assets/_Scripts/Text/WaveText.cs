using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour
{
    public Text nextWave;
    public WaveSpawner waveSpawner;

    private void Start()
    {
        nextWave = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)waveSpawner.waveCountdown != 0)
        {
            nextWave.enabled = true;
            nextWave.text = (int)waveSpawner.waveCountdown + " seconds until next wave...\n Press E to open shop \n Press Q to start next wave";
        }
        else nextWave.enabled = false;

        if (WaveSpawner.finished) nextWave.enabled = false;
    }
}
