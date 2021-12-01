using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthButton : MonoBehaviour
{
    private int healthCost = 1;
    public GameObject player;
    public AudioClip buyClip;
    public AudioSource buySource;

    // Adds health to the player's health
    public void OnClick()
    {
        if (KillText.count >= healthCost && player.GetComponent<PlayerHealth>().health < player.GetComponent<PlayerHealth>().fullHealth)
        {
            buySource.PlayOneShot(buyClip);
            KillText.count -= healthCost;
            player.GetComponent<PlayerHealth>().health += 20;
            player.GetComponent<PlayerHealth>().healthBar.fillAmount =
                player.GetComponent<PlayerHealth>().health / player.GetComponent<PlayerHealth>().fullHealth;
        }
    }
}
