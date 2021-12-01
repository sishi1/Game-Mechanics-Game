using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HotBarNumber2 : MonoBehaviour
{
    public Text hotBar2;

    // Start is called before the first frame update
    void Start()
    {
        hotBar2 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hotBar2.text = "2";
    }
}
