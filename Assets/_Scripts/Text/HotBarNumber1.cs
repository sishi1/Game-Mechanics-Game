using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBarNumber1 : MonoBehaviour
{
    public Text hotBar1;

    // Start is called before the first frame update
    void Start()
    {
        hotBar1 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hotBar1.text = "1";
    }
}
