using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseText : MonoBehaviour
{
    public Text loseText;

    // Start is called before the first frame update
    void Start()
    {
        loseText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.death)
        {
            //loseText.enabled = true;
            //loseText.text = "GAME OVER";
            //Time.timeScale = 0;
        }
        else loseText.enabled = false;
    }
}
