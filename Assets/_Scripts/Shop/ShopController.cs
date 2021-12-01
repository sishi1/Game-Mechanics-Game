using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public GameObject shopPanel;
    public WaveSpawner waveSpawner;

    // Start is called before the first frame update
    void Start()
    {
        shopPanel.SetActive(false);
    }

    private void Update()
    {
        OpenShop();
        AutoCloseShop();
    }

    // Method to open shop when timer != 0
    private void OpenShop()
    {
        if (Input.GetKeyDown(KeyCode.E) && waveSpawner.waveCountdown != 0)
        {
            shopPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopPanel.SetActive(false);
        }

    }

    // Method to auto close the shop when timer is 0
    private void AutoCloseShop()
    {
        if (waveSpawner.waveCountdown <= 0)
        {
            shopPanel.SetActive(false);
        }
    }
}
