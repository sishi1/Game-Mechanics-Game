using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadText : MonoBehaviour
{
    public Text reloadText;
    Shooting reloading;

    // Start is called before the first frame update
    void Start()
    {
        reloadText = GetComponent<Text>();
        reloading = FindObjectOfType<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (reloading.isReloading)
        //{
        //    reloadText.enabled = true;
        //    reloadText.text = "Reloading...";
        //}
        //else reloadText.enabled = false;
    }
}
