using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndKillsText : MonoBehaviour
{
    public Text endKillsText;
    private int endKills;
    private int totalWave;

    void Start()
    {
        endKillsText = GetComponent<Text>();
        endKills = KillText.count;
        totalWave = WaveSpawner.nextWave + 1;
    }

    void Update()
    {
        if (WaveSpawner.finished)
        {
            endKills = KillText.count - BossState.killWorth;
            endKillsText.text = "You've survived throughout all the waves!\nYou've killed " + endKills + " unexchanged zombies and the boss";
        } else endKillsText.text = "You've died in wave " + totalWave + "\nYou've killed " + endKills + " unexchanged zombies";
    }
}
