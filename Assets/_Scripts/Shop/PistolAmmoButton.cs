using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmoButton : MonoBehaviour
{
    private int ammoCost = 2;
    private int clipsYouReceive = 1;
    public GameObject player;
    public AudioClip buyClip;
    public AudioSource buySource;

    // Add pistol clip
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
