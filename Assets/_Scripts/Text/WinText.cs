using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveSpawner.finished)
        {
            winText.enabled = true; 
            winText.text = "CONGRATZ! YOU'VE FINISHED THIS SHIT GAME!";
            Time.timeScale = 0;
        }
        else winText.enabled = false; 
    }
}
