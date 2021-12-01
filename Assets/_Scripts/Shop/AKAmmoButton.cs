using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKAmmoButton : MonoBehaviour
{
    private int ammoCost = 4;
    private int clipsYouReceive = 1;
    public GameObject player;
    public AudioClip buyClip;
    public AudioSource buySource;

    // Add AK clip 
    public void OnClick()
    {
        if (KillText.count >= ammoCost)
        {
            buySource.PlayOneShot(buyClip);
            KillText.count -= ammoCost;
            player.GetComponent<Shooting>().amountsOfClips += clipsYouReceive;
        }
    }
}
