using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillText : MonoBehaviour
{
    public Text killCount;
    public static int count;

    // Start is called before the first frame update
    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
        killCount.text = "Kill count: " + count;
    }
}
